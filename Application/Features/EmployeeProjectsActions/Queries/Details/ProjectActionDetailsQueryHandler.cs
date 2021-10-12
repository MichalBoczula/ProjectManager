using Application.Contracts.Persistance;
using Application.Features.ManagerProjectAction.Queries.EmployeesList;
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
    public class ProjectActionDetailsQueryHandler : IRequestHandler<ProjectActionDetailsQuery, ProjectActionDetailsQueryResult>
    {
        private readonly IProjectManagerDbContext _context;
        private readonly IMapper _mapper;

        public ProjectActionDetailsQueryHandler(IProjectManagerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectActionDetailsQueryResult> Handle(ProjectActionDetailsQuery request, CancellationToken cancellationToken)
        {
            var exceptionList = await ProjectActionDetailsQueryValidator.ValidateAsync(request, _context, cancellationToken);

            if (exceptionList.Count > 0)
            {
                return new ProjectActionDetailsQueryResult(true, exceptionList, null);
            }

            var query = await (from pa in _context.ProjectActions
                               where pa.Id == new Guid(request.ProjectActionId)
                               join m in _context.Managers
                                   on pa.ManagerId equals m.Id
                               select new
                               {
                                   pa,
                                   m
                               })
                               .FirstOrDefaultAsync(cancellationToken);

            var projectActionDetailsVm = new ProjectActionDetailsVm()
            {
                ManagerDto =_mapper.Map<ManagerForProjectDetailsDto>(query.m),
                ProjectActionDto = _mapper.Map<ProjectActionDetailsDto>(query.pa)
            };

            return new ProjectActionDetailsQueryResult(false, exceptionList, projectActionDetailsVm);
        }
    }
}
