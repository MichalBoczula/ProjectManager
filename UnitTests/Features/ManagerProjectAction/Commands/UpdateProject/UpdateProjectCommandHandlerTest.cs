using Application.Contracts.Identity;
using Application.Features.ManagerProjectAction.Commands.UpdateProject;
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

namespace UnitTests.Features.ManagerProjectAction.Commands.UpdateProject
{
    [Collection("CommandCollection")]
    public class UpdateProjectCommandHandlerTest
    {
        private readonly ProjectManagerDbContext _context;
        private const string _email = "PaulAllen@email.com";

        public UpdateProjectCommandHandlerTest()
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
        public async Task ShouldUpdateProject()
        {
            //arrange
            var handler = new UpdateProjectCommandHandler(_context);
            var guid = new Guid("d5212365-524a-430d-ac75-14a0983edf62");
            var title = "Updated title";
            var desc = "Update test description";
            var command = new UpdateProjectCommand()
            {
                Title = title,
                Description = desc,
                ProjectId = guid,
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            var project = await (from p in _context.Projects
                                 where p.Id == guid
                                 select p).FirstOrDefaultAsync();
            project.Title.ShouldBe(title);
            project.Description.ShouldBe(desc);
            project.Id.ShouldBe(guid);
            project.ModifiedBy.ShouldBe(_email);
            project.Modified.ShouldBeInRange(DateTimeOffset.UtcNow.AddMinutes(-1), DateTimeOffset.UtcNow);
        }

        [Fact]
        public async Task ShouldNOTUpdateProject()
        {
            //arrange
            var handler = new UpdateProjectCommandHandler(_context);
            var guid = new Guid("d5212365-524a-430d-aaaa-14a0983edf62");
            var title = "Updated title";
            var desc = "Update test description";
            var command = new UpdateProjectCommand()
            {
                Title = title,
                Description = desc,
                ProjectId = guid,
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }
    }
}
