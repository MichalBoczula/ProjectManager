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
        public async Task ShouldRetrunEmptyGuidInvalidEmail()
        {
            //arrange
            var handler = new ChangeEmployeeInProjectActionCommandHandler(_context);
            var actionId = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            var empId = "7c2cc216-d5cc-4062-97ca-e326e590e9f9";
            var command = new ChangeEmployeeInProjectActionCommand()
            {
                ActionId = actionId,
                EmployeeId = empId,
                Email = "test@email.com"
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldRetrunEmptyGuidInvalidActionId()
        {
            //arrange
            var handler = new ChangeEmployeeInProjectActionCommandHandler(_context);
            var actionId = "aaaaa";
            var empId = "7c2cc216-d5cc-4062-97ca-e326e590e9f9";
            var command = new ChangeEmployeeInProjectActionCommand()
            {
                ActionId = actionId,
                EmployeeId = empId,
                Email = _email
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldRetrunEmptyGuidInvalidEmployeeId()
        {
            //arrange
            var handler = new ChangeEmployeeInProjectActionCommandHandler(_context);
            var actionId = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            var empId = "aaaaa";
            var command = new ChangeEmployeeInProjectActionCommand()
            {
                ActionId = actionId,
                EmployeeId = empId,
                Email = _email
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldRetrunEmptyGuidActionDoesntExist()
        {
            //arrange
            var handler = new ChangeEmployeeInProjectActionCommandHandler(_context);
            var actionId = "21b21a7e-0000-4fa0-850f-0a22f48193dd";
            var empId = "7c2cc216-d5cc-4062-97ca-e326e590e9f9";
            var command = new ChangeEmployeeInProjectActionCommand()
            {
                ActionId = actionId,
                EmployeeId = empId,
                Email = _email
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldRetrunEmptyGuidEmployeeDoesntExist()
        {
            //arrange
            var handler = new ChangeEmployeeInProjectActionCommandHandler(_context);
            var actionId = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            var empId = "7c2cc216-0000-4062-97ca-e326e590e9f9";
            var command = new ChangeEmployeeInProjectActionCommand()
            {
                ActionId = actionId,
                EmployeeId = empId,
                Email = _email
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidEmployeeHasntAssignedToProject()
        {
            //arrange
            var handler = new ChangeEmployeeInProjectActionCommandHandler(_context);
            var actionId = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            var empId = "7c2cc216-d5cc-4062-97ca-e326e590e9f9";
            var command = new ChangeEmployeeInProjectActionCommand()
            {
                ActionId = actionId,
                EmployeeId = empId,
                Email = _email
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldChangeInAction()
        {
            //arrange
            var handler = new ChangeEmployeeInProjectActionCommandHandler(_context);
            var actionId = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            var empId = "c01423b5-9980-4210-92df-3a2fcbf5b664";
            var command = new ChangeEmployeeInProjectActionCommand()
            {
                ActionId = actionId,
                EmployeeId = empId,
                Email = _email
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(new Guid(actionId));
            var query = await (from pa in _context.ProjectActions
                               where pa.Id == new Guid(actionId)
                               select pa).FirstOrDefaultAsync(CancellationToken.None);
            query.EmployeeId.ShouldBe(new Guid(empId));
            query.ModifiedBy.ShouldBe(_email);
            query.Modified.ShouldBeInRange(DateTimeOffset.UtcNow.AddMinutes(-1), DateTimeOffset.UtcNow);
        }
    }
}
