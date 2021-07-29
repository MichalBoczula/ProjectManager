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
            var empId = new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664");
            var projectId = new Guid("d5212365-524a-430d-ac75-14a0983edf62");
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
            result.EmployeeId.ShouldBe(empId);
            result.ProjectId.ShouldBe(projectId);
            result.ManagerId.ShouldBe(managerGuid);
            var query = await (from pem in _context.ProjectEmployeeManagers
                             where pem.EmployeeId == empId
                             && pem.ManagerId == managerGuid
                             && pem.ProjectId == projectId
                             select pem).FirstOrDefaultAsync();
            query.ShouldBeNull();
            var actions = await (from pa in _context.ProjectActions
                               where pa.EmployeeId == empId
                               && pa.ProjectId == projectId
                               select pa).ToListAsync();
            actions.ShouldBeEmpty();
        }

        [Fact]
        public async Task ShouldNOTRemoveEmployeeFromProject()
        {
            //arrange
            var handle = new RemoveEmployeeFromProjectCommandHandler(_context);
            var empId = new Guid("c01423b5-9980-4210-aaaa-3a2fcbf5b664");
            var projectId = new Guid("d5212365-524a-430d-ac75-14a0983edf62");
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
