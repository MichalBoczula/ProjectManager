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

namespace Application.Features.EmployeeProjectsActions.Queries.List
{
    public class ProjectsListForEmployeeQueryHandler : IRequestHandler<ProjectsListForEmployeeQuery, List<ProjectVm>>
    {
        private readonly IProjectManagerDbContext _context;
        private readonly IMapper _mapper;

        public ProjectsListForEmployeeQueryHandler(IProjectManagerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProjectVm>> Handle(ProjectsListForEmployeeQuery request, CancellationToken cancellationToken)
        {

            var empIdQuery = from e in _context.Employees
                             where e.Email == request.Email
                             select new
                             {
                                 e.Id
                             };
            var actions = from pa in _context.ProjectActions
                          join q in empIdQuery
                              on pa.EmployeeId equals q.Id
                          orderby pa.ProjectId
                          select pa;

            var projects = (from p in _context.Projects
                            join q in actions
                                 on p.Id equals q.ProjectId
                            select p).Distinct();

            var result = new List<ProjectVm>();
            var proj = new List<ProjectInformationDto>();

            foreach (var ele in projects)
            {
                var project = _mapper.Map<ProjectInformationDto>(ele);
                result.Add(new ProjectVm
                {
                    Project = project,
                    ProjectActions = new List<ProjectActionDto>()
                });
            }

            foreach (var ele in actions)
            {
                var actionDto = _mapper.Map<ProjectActionDto>(ele);
                foreach (var item in result)
                {
                    var projectVm = new ProjectVm()
                    {
                        ProjectActions = new List<ProjectActionDto>()
                    };
                    if (ele.ProjectId == item.Project.Id)
                    {
                        item.ProjectActions.Add(actionDto);
                    }
                }
            }

            if(result.Count > 0)
            {
                return result;

            }
            else
            {
                return null;
            }
        }
    }
}
