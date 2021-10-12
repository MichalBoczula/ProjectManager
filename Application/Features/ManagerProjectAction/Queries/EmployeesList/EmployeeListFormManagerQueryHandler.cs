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

namespace Application.Features.ManagerProjectAction.Queries.EmployeesList
{
    public class EmployeeListFormManagerQueryHandler : IRequestHandler<EmployeeListFormManagerQuery, EmployeeForManagerQueryResult>
    {
        private readonly IProjectManagerDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeListFormManagerQueryHandler(IProjectManagerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<EmployeeForManagerQueryResult> Handle(EmployeeListFormManagerQuery request, CancellationToken cancellationToken)
        {
            var exceptionsList = await EmployeeListForManagerValidator.ValidateAsync(request, _context, cancellationToken);

            if (exceptionsList.Count > 0)
            {
                return new EmployeeForManagerQueryResult(true, exceptionsList, null);
            }

            var manager = from m in _context.Managers
                          where request.Email == m.Email
                          select m.Id;

            var employees = from e in _context.Employees
                            select e;

            var result = new List<EmployeeForManagerVm>();

            foreach (var ele in await employees.ToListAsync(cancellationToken))
            {
                result.Add(_mapper.Map<EmployeeForManagerVm>(ele));
            }

            return  new EmployeeForManagerQueryResult(false, null, result);
        }
    }
}
