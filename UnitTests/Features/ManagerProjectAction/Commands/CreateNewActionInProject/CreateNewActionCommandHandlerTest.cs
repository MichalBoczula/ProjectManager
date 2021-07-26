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
            var guid = new Guid("d5212365-524a-430d-ac75-14a0983edf62");
            var title = "test title";
            var desc = "test description";
            var deadline = DateTimeOffset.Now.AddMonths(1);
            var empId = new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664");
            var command = new CreateNewActionCommand()
            {
                ProjectId = guid,
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
            action.ProjectId.ShouldBe(guid);
            action.Title.ShouldBe(title);
            action.Description.ShouldBe(desc);
            action.DeadLine.ShouldBe(deadline);
            action.EmployeeId.ShouldBe(empId);
            action.Status.ShouldBe(ProgressStatus.ToDo);
            action.StatusId.ShouldBe(1);
            action.CreatedBy.ShouldBe(_email);
            action.ManagerId.ShouldBe(managerId);
            action.Created.ShouldBeInRange(DateTimeOffset.Now.AddMinutes(-1), DateTimeOffset.Now);
        }
    }
}
