using Application.Contracts.Persistance;
using AutoMapper;
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

            if (!String.IsNullOrWhiteSpace(request.ActionStatus))
            {
                query = from q in query
                        where request.ActionStatus == q.Status.ToString()
                        select q;
            }

            if (!String.IsNullOrWhiteSpace(request.ActionName))
            {
                query = from q in query
                        where q.Title.Contains(request.ActionName)
                        select q;
            }

            if(request.Skip > 0)
            {
                query = (from q in query
                         select q).Skip(request.Skip);
            }

            if (request.Take > 0)
            {
                query = (from q in query
                         select q).Take(request.Take);
            }

            var projects = from q in query
                           join p in _context.Projects
                                on q.ProjectId equals p.Id
                           select p;

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
    }
}
