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

namespace Application.Features.EmployeeProjectsActions.Queries.Details
{
    public class ProjectActionDetailsQueryHandler : IRequestHandler<ProjectActionDetailsQuery, ProjectActionDetailsVm>
    {
        private readonly IProjectManagerDbContext _context;
        private readonly IMapper _mapper;

        public ProjectActionDetailsQueryHandler(IProjectManagerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectActionDetailsVm> Handle(ProjectActionDetailsQuery request, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(request.ProjectActionId, out Guid guid))
            {
                return null;
            }

            var employeeId = await (from e in _context.Employees
                                    where e.Email == request.Email
                                    select e.Id)
                                    .FirstOrDefaultAsync(cancellationToken);

            if(employeeId == Guid.Empty)
            {
                return null;
            }

            var query = await (from pa in _context.ProjectActions
                               where pa.Id == guid
                               join m in _context.Managers
                                   on pa.ManagerId equals m.Id
                               select new
                               {
                                   pa,
                                   m
                               })
                               .FirstOrDefaultAsync(cancellationToken);

            if (query != null)
            {
                var projectActionDetailsVm = new ProjectActionDetailsVm()
                {
                    ManagerDto = _mapper.Map<ManagerForProjectDetailsDto>(query.m),
                    ProjectActionDto = _mapper.Map<ProjectActionDetailsDto>(query.pa)
                };
                return projectActionDetailsVm;
            }
            else
            {
                return null;
            }
        }
    }
}
