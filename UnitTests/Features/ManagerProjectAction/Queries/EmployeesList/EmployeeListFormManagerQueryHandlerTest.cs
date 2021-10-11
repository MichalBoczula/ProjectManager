using Application.Features.Common.Exceptions;
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
            var result = await handler.Handle(new EmployeeListFormManagerQuery()
            {
                Email = "PaulAllen@email.com"
            }, CancellationToken.None);
            //assert
            result.ShouldBeOfType<EmployeeForManagerQueryResult>();
            result.AreThereException.ShouldBeFalse();
            result.ExceptionsList.ShouldBeNull();
            foreach (var emp in result.Vm)
            {
                emp.FullName.ShouldBeOfType<string>();
                emp.FullName.ShouldNotBeNullOrWhiteSpace();
                emp.Email.ShouldBeOfType<string>();
                emp.Email.ShouldNotBeNullOrWhiteSpace();
            }
        }

        [Fact]
        public async Task ShouldExceptionsList()
        {
            //arrange
            var handler = new EmployeeListFormManagerQueryHandler(_context, _mapper);
            //act
            var result = await handler.Handle(new EmployeeListFormManagerQuery()
            {
                Email = "test@email.com"
            }, CancellationToken.None);
            //assert
            result.ShouldBeOfType<EmployeeForManagerQueryResult>();
            result.AreThereException.ShouldBeTrue();
            result.Vm.ShouldBeNull();
            result.ExceptionsList.Count.ShouldBe(1);
            result.ExceptionsList[0].ShouldBeOfType<ManagerEmptyGuidException>();
            result.ExceptionsList[0].Message.ShouldBe("Manager with  this GUID doesn't exists, Please check GUID");
        }
    }
}
