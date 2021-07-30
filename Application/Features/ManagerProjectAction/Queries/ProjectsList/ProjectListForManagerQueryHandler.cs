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

namespace Application.Features.ManagerProjectAction.Queries.ProjectsList
{
    public class ProjectListForManagerQueryHandler : IRequestHandler<ProjectListForManagerQuery, List<ProjectForManagersList>>
    {
        private readonly IProjectManagerDbContext _context;
        private readonly IMapper _mapper;

        public ProjectListForManagerQueryHandler(IProjectManagerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ProjectForManagersList>> Handle(ProjectListForManagerQuery request, CancellationToken cancellationToken)
        {
            var managerId = await (from m in _context.Managers
                                   where m.Email == request.Email
                                   select m.Id).FirstOrDefaultAsync(cancellationToken);
            var projectIds = await (from pem in _context.ProjectEmployeeManagers
                               where pem.ManagerId == managerId
                               select pem.ProjectId).ToListAsync(cancellationToken);
            var projects = from p in _context.Projects
                           where projectIds.Contains(p.Id)
                           select p;

            var result = new List<ProjectForManagersList>();
            foreach(var project in await projects.ToListAsync())
            {
                result.Add(_mapper.Map<ProjectForManagersList>(project));
            }

            return result;
        }
    }
}
