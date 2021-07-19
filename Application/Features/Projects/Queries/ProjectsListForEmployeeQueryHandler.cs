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

            var query = from e in _context.Employees
                        where e.Email == request.Email
                        join pa in _context.ProjectActions
                            on e.Id equals pa.EmployeeId
                        join p in _context.Projects
                            on pa.ProjectId equals p.Id
                        group pa by p.Id into x
                        select x;
            var list = new List<ProjectVm>();
            var l = query.ToListAsync(cancellationToken: cancellationToken);
            //foreach (var ele in await query.ToListAsync(cancellationToken: cancellationToken))
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
