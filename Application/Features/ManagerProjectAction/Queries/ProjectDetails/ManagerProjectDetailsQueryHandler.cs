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

namespace Application.Features.ManagerProjectAction.Queries.ProjectDetails
{
    public class ManagerProjectDetailsQueryHandler : IRequestHandler<ManagerProjectDetailsQuery, ProjectDetailsForManagersVm>
    {
        private readonly IProjectManagerDbContext _context;
        private readonly IMapper _mapper;

        public ManagerProjectDetailsQueryHandler(IProjectManagerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ProjectDetailsForManagersVm> Handle(ManagerProjectDetailsQuery request, CancellationToken cancellationToken)
        {
            var managerId = from m in _context.Managers
                            where m.Email == request.Email
                            select m.Id;

            if(await managerId.FirstOrDefaultAsync(cancellationToken: cancellationToken) == Guid.Empty)
            {
                return null;
            }

            var project = from p in _context.Projects
                          where p.Id == new Guid(request.ProjectId)
                          select p;

            var actionsAndEmployee = from pa in _context.ProjectActions
                                     where new Guid(request.ProjectId) == pa.ProjectId
                                     join e in _context.Employees
                                          on pa.EmployeeId equals e.Id
                                     select new
                                     {
                                         Action = pa,
                                         Emp = e
                                     };

            var result = new ProjectDetailsForManagersVm()
            {
                Project = _mapper.Map<ProjectForManagersDto>(await project.FirstOrDefaultAsync(cancellationToken))
            };

            foreach (var ele in actionsAndEmployee)
            {
                var action = _mapper.Map<ProjectActionForMangersProjectDetailsDto>(ele.Action);
                action.Employee = _mapper.Map<EmployeeForManagersProjectDetailsDto>(ele.Emp);
                result.ProjectActions.Add(action);
            }

            return result.ProjectActions.Count > 0 ?
                result :
                null;
        }
    }
}
