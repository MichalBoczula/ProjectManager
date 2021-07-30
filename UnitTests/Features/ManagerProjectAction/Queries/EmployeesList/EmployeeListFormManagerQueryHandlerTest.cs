using Application.Features.ManagerProjectAction.Queries.EmployeesList;
using AutoMapper;
using Persistance.Context;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnitTests.Common;
using Xunit;

namespace UnitTests.Features.ManagerProjectAction.Queries.EmployeesList
{
    [Collection("QueryCollection")]
    public class EmployeeListFormManagerQueryHandlerTest
    {
        private readonly ProjectManagerDbContext _context;
        private readonly IMapper _mapper;

        public EmployeeListFormManagerQueryHandlerTest(QueryTestBase testBase)
        {
            _context = testBase.Context;
            _mapper = testBase.Mapper;
        }

        [Fact]
        public async Task ShouldReturnEmployeesList()
        {
            //arrange
            var handler = new EmployeeListFormManagerQueryHandler(_context, _mapper);
            //act
            var result = await handler.Handle(new EmployeeListFormManagerQuery(), CancellationToken.None);
            //assert
            result.ShouldBeOfType<List<EmployeeForManagerVm>>();
            foreach(var emp in result)
            {
                emp.FullName.ShouldBeOfType<string>();
                emp.FullName.ShouldNotBeNullOrWhiteSpace();
                emp.Email.ShouldBeOfType<string>();
                emp.Email.ShouldNotBeNullOrWhiteSpace();
            }
        }
    }
}
