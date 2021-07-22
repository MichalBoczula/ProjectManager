﻿using Application.Contracts.Persistance;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Projects.Queries
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

            var eId = from e in _context.Employees
                      where e.Email == request.Email
                      select e.Id;
            var query = from pa in _context.ProjectActions.AsEnumerable()
                        where pa.EmployeeId == eId.FirstOrDefault()
                        group pa by pa.ProjectId into x
                        select new
                        {
                            x.Key,
                            Actions = x.ToList()
                        };

            var list = new List<ProjectVm>();
            //foreach (var ele in query)
            //{
            //    var projectVm = new ProjectVm()
            //    {
            //        ProjectAction = _mapper.Map<ProjectActionDto>(ele.pa)
            //    };
            //    list.Add(projectVm);
            //}
            return list;
        }
    }
}
