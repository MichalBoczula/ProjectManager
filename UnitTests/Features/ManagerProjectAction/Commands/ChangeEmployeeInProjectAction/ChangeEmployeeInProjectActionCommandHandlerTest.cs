using Application.Contracts.Identity;
using Application.Features.ManagerProjectAction.Commands.ChangeEmployeeInProjectAction;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistance.Context;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Features.ManagerProjectAction.Commands.ChangeEmployeeInProjectAction
{
    [Collection("CommandCollection")]
    public class ChangeEmployeeInProjectActionCommandHandlerTest
    {
        private readonly ProjectManagerDbContext _context;
        private const string _email = "PaulAllen@email.com";

        public ChangeEmployeeInProjectActionCommandHandlerTest()
        {
            var mockUserService = new Mock<ICurrentUserService>();
            mockUserService.Setup(x => x.Email).Returns(_email);
            var options = new DbContextOptionsBuilder<ProjectManagerDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var _contextMock = new Mock<ProjectManagerDbContext>(options, mockUserService.Object) { CallBase = true };
            _context = _contextMock.Object;
            _context.Database.EnsureCreated();
            _context.SaveChanges();
        }

        [Fact]
        public async Task ShouldChangeEmployee()
        {
            //arrange
            var handler = new ChangeEmployeeInProjectActionCommandHandler(_context);
            var actionId = new Guid("21b21a7e-402f-4fa0-850f-0a22f48193dd");
            var empId = new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9");
            var command = new ChangeEmployeeInProjectActionCommand()
            {
                ActionId = actionId,
                EmployeeId = empId
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(actionId);
            var actionEmpId = await (from pa in _context.ProjectActions
                                where pa.Id == actionId
                                select pa.EmployeeId).FirstOrDefaultAsync();
            actionEmpId.ShouldBe(empId);
        }

        [Fact]
        public async Task ShouldNOTChangeEmployeeWrongEmployeeId()
        {
            //arrange
            var handler = new ChangeEmployeeInProjectActionCommandHandler(_context);
            var actionId = new Guid("21b21a7e-402f-4fa0-850f-0a22f48193dd");
            var empId = new Guid("7c2cc216-d5cc-4062-aaaa-e326e590e9f9");
            var command = new ChangeEmployeeInProjectActionCommand()
            {
                ActionId = actionId,
                EmployeeId = empId
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldNOTChangeEmployeeWrongActionId()
        {
            //arrange
            var handler = new ChangeEmployeeInProjectActionCommandHandler(_context);
            var actionId = new Guid("21b21a7e-402f-4fa0-aaaa-0a22f48193dd");
            var empId = new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9");
            var command = new ChangeEmployeeInProjectActionCommand()
            {
                ActionId = actionId,
                EmployeeId = empId
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }
    }
}
