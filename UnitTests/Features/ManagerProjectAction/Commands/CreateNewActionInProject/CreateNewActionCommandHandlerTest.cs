using Application.Contracts.Identity;
using Application.Features.ManagerProjectAction.Commands.CreateNewActionInProject;
using Domain.Entities;
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

namespace UnitTests.Features.ManagerProjectAction.Commands.CreateNewActionInProject
{
    [Collection("CommandCollection")]
    public class CreateNewActionCommandHandlerTest
    {
        private readonly ProjectManagerDbContext _context;
        private const string _email = "PaulAllen@email.com";

        public CreateNewActionCommandHandlerTest()
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
        public async Task ShouldAddNewProjectsAction()
        {
            //arrange
            var handler = new CreateNewActionCommandHandler(_context);
            var projId = "d5212365-524a-430d-ac75-14a0983edf62";
            var title = "test title";
            var desc = "test description";
            var deadline = "2/10/2021";
            var empId = "c01423b5-9980-4210-92df-3a2fcbf5b664";
            var command = new CreateNewActionCommand()
            {
                ProjectId = projId,
                Title = title,
                Description = desc,
                Email = _email,
                DeadLine = deadline,
                EmployeeId = empId
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            var managerId = await (from m in _context.Managers
                                   where m.Email == _email
                                   select m.Id).FirstOrDefaultAsync();
            var action = await (from pa in _context.ProjectActions
                                where pa.Id == result
                                select pa).FirstOrDefaultAsync();
            action.Id.ShouldBe(result);
            action.ProjectId.ShouldBe(new Guid(projId));
            action.Title.ShouldBe(title);
            action.Description.ShouldBe(desc);
            action.DeadLine.ShouldBe(DateTimeOffset.Parse(deadline));
            action.EmployeeId.ShouldBe(new Guid(empId));
            action.Status.ShouldBe(ProgressStatus.ToDo);
            action.StatusId.ShouldBe(1);
            action.CreatedBy.ShouldBe(_email);
            action.ManagerId.ShouldBe(managerId);
            action.Created.ShouldBeInRange(DateTimeOffset.Now.AddMinutes(-1), DateTimeOffset.Now);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidInvalidEmail()
        {
            //arrange
            var handler = new CreateNewActionCommandHandler(_context);
            var projId = "d5212365-524a-430d-ac75-14a0983edf62";
            var title = "test title";
            var desc = "test description";
            var deadline = "2/10/2021";
            var empId = "c01423b5-9980-4210-92df-3a2fcbf5b664";
            var command = new CreateNewActionCommand()
            {
                ProjectId = projId,
                Title = title,
                Description = desc,
                Email = "aaaaa",
                DeadLine = deadline,
                EmployeeId = empId
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidEmployeeDoesntExist()
        {
            //arrange
            var handler = new CreateNewActionCommandHandler(_context);
            var projId = "d5212365-524a-430d-ac75-14a0983edf62";
            var title = "test title";
            var desc = "test description";
            var deadline = "2/10/2021";
            var empId = "c01423b5-aaaa-4210-92df-3a2fcbf5b664";
            var command = new CreateNewActionCommand()
            {
                ProjectId = projId,
                Title = title,
                Description = desc,
                Email = _email,
                DeadLine = deadline,
                EmployeeId = empId
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidInvalidEmployeeId()
        {
            //arrange
            var handler = new CreateNewActionCommandHandler(_context);
            var projId = "d5212365-524a-430d-ac75-14a0983edf62";
            var title = "test title";
            var desc = "test description";
            var deadline = "2/10/2021";
            var empId = "aaaaa";
            var command = new CreateNewActionCommand()
            {
                ProjectId = projId,
                Title = title,
                Description = desc,
                Email = _email,
                DeadLine = deadline,
                EmployeeId = empId
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidProjectDoesntExist()
        {
            //arrange
            var handler = new CreateNewActionCommandHandler(_context);
            var projId = "d5212365-aaaa-430d-ac75-14a0983edf62";
            var title = "test title";
            var desc = "test description";
            var deadline = "2/10/2021";
            var empId = "c01423b5-9980-4210-92df-3a2fcbf5b664";
            var command = new CreateNewActionCommand()
            {
                ProjectId = projId,
                Title = title,
                Description = desc,
                Email = _email,
                DeadLine = deadline,
                EmployeeId = empId
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidInvalidProjectId()
        {
            //arrange
            var handler = new CreateNewActionCommandHandler(_context);
            var projId = "aaaaa";
            var title = "test title";
            var desc = "test description";
            var deadline = "2/10/2021";
            var empId = "c01423b5-9980-4210-92df-3a2fcbf5b664";
            var command = new CreateNewActionCommand()
            {
                ProjectId = projId,
                Title = title,
                Description = desc,
                Email = _email,
                DeadLine = deadline,
                EmployeeId = empId
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidDateTimeCantBeParse()
        {
            //arrange
            var handler = new CreateNewActionCommandHandler(_context);
            var projId = "d5212365-524a-430d-ac75-14a0983edf62";
            var title = "test title";
            var desc = "test description";
            var deadline = "aaaaa";
            var empId = "c01423b5-9980-4210-92df-3a2fcbf5b664";
            var command = new CreateNewActionCommand()
            {
                ProjectId = projId,
                Title = title,
                Description = desc,
                Email = _email,
                DeadLine = deadline,
                EmployeeId = empId
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidActionHasBeenAlreadyCreated()
        {
            //arrange
            var handler = new CreateNewActionCommandHandler(_context);
            var projId = "d5212365-524a-430d-ac75-14a0983edf62";
            var title = "API";
            var desc = "Create API Controllers";
            var deadline = "2/10/2021";
            var empId = "c01423b5-9980-4210-92df-3a2fcbf5b664";
            var command = new CreateNewActionCommand()
            {
                ProjectId = projId,
                Title = title,
                Description = desc,
                Email = _email,
                DeadLine = deadline,
                EmployeeId = empId
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(Guid.Empty);
        }
    }
}
