using Application.Contracts.Identity;
using Application.Features.ManagerProjectAction.Commands.CreateNewProject;
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

namespace UnitTests.Features.ManagerProjectAction.Commands.CreateNewProject
{
    [Collection("CommandCollection")]
    public class CreateNewProjectCommandHandlerTest
    {
        private readonly ProjectManagerDbContext _context;
        private const string _email = "PaulAllen@email.com";

        public CreateNewProjectCommandHandlerTest()
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
        public async Task ShouldAddNewProject()
        {
            //arrange 
            var handler = new CreateNewProjectCommandHandler(_context);
            var title = "test title";
            var desc = "test Description";
            var emps = new HashSet<Guid>()
            {
                new Guid("c01423b5-9980-4210-92df-3a2fcbf5b664"),
                new Guid("9ce70e45-55f3-4d53-af03-e1b24c97339b")
            };
            var command = new CreateNewProjectCommand()
            {
                Title = title,
                Description = desc,
                Email = _email,
                Employees = emps
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            var project = await (from p in _context.Projects
                                 where p.Id == result
                                 select p).FirstOrDefaultAsync();
            project.Title.ShouldBe(title);
            project.Description.ShouldBe(desc);
            project.CreatedBy.ShouldBe(_email);
            project.StatusId.ShouldBe(1);
            project.Status.ShouldBe(ProjectStatus.Open);
            project.Created.ShouldBeInRange(DateTimeOffset.Now.AddMinutes(-1), DateTimeOffset.Now);
            var projectEmployeeManagerList = from pem in _context.ProjectEmployeeManagers
                                             where pem.ProjectId == result
                                             select new
                                             {
                                                 pem.ManagerId,
                                                 pem.EmployeeId
                                             };
            var mangerId = await (from m in _context.Managers
                                  where m.Email == _email
                                  select m.Id).FirstOrDefaultAsync();
            foreach (var ele in await projectEmployeeManagerList.ToListAsync())
            {
                ele.ManagerId.ShouldBe(mangerId);
                emps.Contains(ele.EmployeeId).ShouldBeTrue();
            }
        }
    }
}
