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

namespace Application.Features.ProjectsActions.Queries.Details
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
            var query = await (from pa in _context.ProjectActions
                               where pa.Id == request.ProjectActionId
                               join m in _context.Managers
                                   on pa.ManagerId equals m.Id
                               select new
                               {
                                   pa,
                                   m
                               }).FirstOrDefaultAsync(cancellationToken);
            var projectActionDetailsVm = new ProjectActionDetailsVm()
            {
                ManagerDto = _mapper.Map<ManagerForProjectDetailsDto>(query.m),
                ProjectActionDto = _mapper.Map<ProjectActionDetailsDto>(query.pa)
            };
            return projectActionDetailsVm;
        }
    }
}
