using Application.Contracts.Persistance;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ManagerProjectAction.Queries.ProjectActionWithFilter
{
    public class ProjectActionWithFilterQueryHandler : IRequestHandler<ProjectActionWithFilterQuery, List<ProjectActionWithFilterVm>>
    {
        private readonly IProjectManagerDbContext _context;
        private readonly IMapper _mapper;

        public ProjectActionWithFilterQueryHandler(IProjectManagerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProjectActionWithFilterVm>> Handle(ProjectActionWithFilterQuery request, CancellationToken cancellationToken)
        {
            var managerId = await (from m in _context.Managers
                                   where m.Email == request.Email
                                   select m.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);

            if (managerId == Guid.Empty)
            {
                return null;
            }

            var query = from pa in _context.ProjectActions
                        where pa.ManagerId == managerId
                        select pa;

            var s = (from q in query
                     select q.Status.ToString().ToLower()).Distinct().ToList();

            if (!String.IsNullOrWhiteSpace(request.ActionStatus))
            {
                var status = CheckStatusAndMapToProgressStatusEnum(request.ActionStatus);

                if (status.Item2)
                {
                    query = from q in query
                            where status.Item1 == q.Status
                            select q;
                }
            }

            if (!String.IsNullOrWhiteSpace(request.ActionName))
            {
                query = from q in query
                        where q.Title.Contains(request.ActionName)
                        select q;
            }

            if (request.Skip > 0)
            {
                query = (from q in query
                         select q).Skip(request.Skip);
            }

            if (request.Take > 0)
            {
                query = (from q in query
                         select q).Take(request.Take);
            }
            else
            {
                query = (from q in query
                         select q).Take(10);
            }

            var projects = (from q in query
                            join p in _context.Projects
                                 on q.ProjectId equals p.Id
                            select p).Distinct();

            var result = new List<ProjectActionWithFilterVm>();

            foreach (var proj in projects)
            {
                var item = new ProjectActionWithFilterVm()
                {
                    Project = _mapper.Map<ProjectForProjectActionWithFilterDto>(proj),
                    ProjectActions = new List<ProjectActionForProjectActionWithFilterDto>()
                };
                result.Add(item);
            }

            foreach (var action in query)
            {
                foreach (var item in result)
                {
                    if (action.ProjectId == item.Project.Id)
                    {
                        item.ProjectActions.Add(_mapper.Map<ProjectActionForProjectActionWithFilterDto>(action));
                    }
                }
            }

            return result;
        }

        private Tuple<ProgressStatus, bool> CheckStatusAndMapToProgressStatusEnum(string actionStatus)
        {
            ProgressStatus status = ProgressStatus.ToDo;
            bool flag = true;
            switch (actionStatus.ToLower())
            {
                case "todo":
                    {
                        status = ProgressStatus.ToDo;
                        break;
                    }
                case "tocheck":
                    {
                        status = ProgressStatus.ToCheck;
                        break;
                    }
                case "toimprove":
                    {
                        status = ProgressStatus.ToImprove;
                        break;
                    }
                case "done":
                    {
                        status = ProgressStatus.Done;
                        break;
                    }
                default:
                    flag = false;
                    break;
            }

            return Tuple.Create(status, flag);
        }
    }
}
