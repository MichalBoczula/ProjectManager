using Application.Contracts.Identity;
using Application.Features.ManagerProjectAction.Commands.AddEmployeeToProject;
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

namespace UnitTests.Features.ManagerProjectAction.Commands.AddEmployeeToProject
{
    [Collection("CommandCollectiion")]
    public class AddEmployeeToProjectCommandHandlerTest
    {
        private readonly ProjectManagerDbContext _context;
        private const string _email = "PaulAllen@email.com";

        public AddEmployeeToProjectCommandHandlerTest()
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
        public async Task ShouldAddEmployeeToProject()
        {
            //arrange
            var handle = new AddEmployeeToProjectCommandHandler(_context);
            var empId = new Guid("7c2cc216-d5cc-4062-97ca-e326e590e9f9");
            var projectId = new Guid("d5212365-524a-430d-ac75-14a0983edf62");
            var managerGuid = new Guid("b517ef40-f882-48cf-8649-cbca908e0787");
            var command = new AddEmployeeToProjectCommand()
            {
                EmployeeId = empId,
                ProjectId = projectId,
                Email =_email
            };
            //act
            var result = await handle.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<ProjectEmployeeManager>();
            result.EmployeeId.ShouldBe(empId);
            result.ProjectId.ShouldBe(projectId);
            result.ManagerId.ShouldBe(managerGuid);
        }

        [Fact]
        public async Task ShoulNOTdAddEmployeeToProject()
        {
            //arrange
            var handle = new AddEmployeeToProjectCommandHandler(_context);
            var empId = new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664");
            var projectId = new Guid("d5212365-524a-430d-ac75-14a0983edf62");
            var command = new AddEmployeeToProjectCommand()
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
