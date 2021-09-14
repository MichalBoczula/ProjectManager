using Application.Contracts.Identity;
using Application.Features.ManagerProjectAction.Commands.RemoveEmployeeFromProject;
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

namespace UnitTests.Features.ManagerProjectAction.Commands.RemoveEmployeeFromProject
{
    [Collection("CommandCollection")]
    public class RemoveEmployeeFromProjectCommandHandlerTest
    {
        private readonly ProjectManagerDbContext _context;
        private const string _email = "PaulAllen@email.com";

        public RemoveEmployeeFromProjectCommandHandlerTest()
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
        public async Task ShouldRemoveEmployeeFromProject()
        {
            //arrange
            var handle = new RemoveEmployeeFromProjectCommandHandler(_context);
            var empId = "c01423b5-9980-4210-92df-3a2fcbf5b664";
            var projectId = "d5212365-524a-430d-ac75-14a0983edf62";
            var managerGuid = new Guid("b517ef40-f882-48cf-8649-cbca908e0787");
            var command = new RemoveEmployeeFromProjectCommand()
            {
                EmployeeId = empId,
                ProjectId = projectId,
                Email = _email
            };
            //act
            var result = await handle.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<ProjectEmployeeManager>();
            result.EmployeeId.ShouldBe(new Guid(empId));
            result.ProjectId.ShouldBe(new Guid(projectId));
            result.ManagerId.ShouldBe(managerGuid);
            var query = await (from pem in _context.ProjectEmployeeManagers
                             where pem.EmployeeId == new Guid(empId)
                             && pem.ManagerId == managerGuid
                             && pem.ProjectId == new Guid(projectId)
                             select pem).FirstOrDefaultAsync();
            query.ShouldBeNull();
            var actions = await (from pa in _context.ProjectActions
                               where pa.EmployeeId == new Guid(empId)
                               && pa.ProjectId == new Guid(projectId)
                               select pa).ToListAsync();
            actions.ShouldBeEmpty();
        }

        [Fact]
        public async Task ShouldReturnNullInvalidProjectId()
        {
            //arrange
            var handle = new RemoveEmployeeFromProjectCommandHandler(_context);
            var empId = "c01423b5-9980-4210-92df-3a2fcbf5b664";
            var projectId ="aaaaa";
            var command = new RemoveEmployeeFromProjectCommand()
            {
                EmployeeId = empId,
                ProjectId = projectId,
                Email = _email
            };
            //act
            var result = await handle.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeNull();
        }

        [Fact]
        public async Task ShouldReturnNullInvalidEmployeeId()
        {
            //arrange
            var handle = new RemoveEmployeeFromProjectCommandHandler(_context);
            var empId = "aaaaa";
            var projectId = "d5212365-524a-430d-ac75-14a0983edf62";
            var command = new RemoveEmployeeFromProjectCommand()
            {
                EmployeeId = empId,
                ProjectId = projectId,
                Email = _email
            };
            //act
            var result = await handle.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeNull();
        }

        [Fact]
        public async Task ShouldReturnNullInvalidEmail()
        {
            //arrange
            var handle = new RemoveEmployeeFromProjectCommandHandler(_context);
            var empId ="c01423b5-9980-4210-92df-3a2fcbf5b664";
            var projectId = "d5212365-524a-430d-ac75-14a0983edf62";
            var command = new RemoveEmployeeFromProjectCommand()
            {
                EmployeeId = empId,
                ProjectId = projectId,
                Email = "aaaaa"
            };
            //act
            var result = await handle.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeNull();
        }

        [Fact]
        public async Task ShouldReturnNullEmployeeInProjectDoesNOTExists()
        {
            //arrange
            var handle = new RemoveEmployeeFromProjectCommandHandler(_context);
            var empId = "c01423b5-aaaa-4210-92df-3a2fcbf5b664";
            var projectId = "d5212365-524a-430d-ac75-14a0983edf62";
            var command = new RemoveEmployeeFromProjectCommand()
            {
                EmployeeId = empId,
                ProjectId = projectId,
                Email = _email
            };
            //act
            var result = await handle.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeNull();
        }

        [Fact]
        public async Task ShouldReturnNullProjectDoesNOTExists()
        {
            //arrange
            var handle = new RemoveEmployeeFromProjectCommandHandler(_context);
            var empId = "c01423b5-9980-4210-92df-3a2fcbf5b664";
            var projectId = "d5212365-aaaa-430d-ac75-14a0983edf62";
            var command = new RemoveEmployeeFromProjectCommand()
            {
                EmployeeId = empId,
                ProjectId = projectId,
                Email = _email
            };
            //act
            var result = await handle.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeNull();
        }

        [Fact]
        public async Task ShouldReturnEmployeeIsNOTAssignedToProject()
        {
            //arrange
            var handle = new RemoveEmployeeFromProjectCommandHandler(_context);
            var empId = "7c2cc216-d5cc-4062-97ca-e326e590e9f9";
            var projectId = "d5212365-524a-430d-ac75-14a0983edf62";
            var command = new RemoveEmployeeFromProjectCommand()
            {
                EmployeeId = empId,
                ProjectId = projectId,
                Email = _email
            };
            //act
            var result = await handle.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeNull();
        }
    }
}
