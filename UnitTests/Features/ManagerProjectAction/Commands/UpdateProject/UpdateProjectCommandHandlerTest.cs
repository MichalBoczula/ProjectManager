using Application.Contracts.Identity;
using Application.Features.ManagerProjectAction.Commands.UpdateProject;
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
        public async Task ShouldReturnEmptyGuidInvalidEmail()
        {
            //arrange
            var handler = new UpdateProjectCommandHandler(_context);
            var guid = "d5212365-524a-430d-ac75-14a0983edf62";
            var title = "Updated title";
            var desc = "Update test description";
            var command = new UpdateProjectCommand()
            {
                Title = title,
                Description = desc,
                ProjectId = guid,
                Email = "aaaa"
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidInvalidProjectId()
        {
            //arrange
            var handler = new UpdateProjectCommandHandler(_context);
            var guid = "aaaaa";
            var title = "Updated title";
            var desc = "Update test description";
            var command = new UpdateProjectCommand()
            {
                Title = title,
                Description = desc,
                ProjectId = guid,
                Email = _email
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidManagerDoesntLeadProject()
        {
            //arrange
            var handler = new UpdateProjectCommandHandler(_context);
            var guid = "d5212365-aaaa-430d-ac75-14a0983edf62";
            var title = "Updated title";
            var desc = "Update test description";
            var command = new UpdateProjectCommand()
            {
                Title = title,
                Description = desc,
                ProjectId = guid,
                Email = _email
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidProjectDoesntExists()
        {
            //arrange
            var handler = new UpdateProjectCommandHandler(_context);
            var guid = "d5212365-aaaa-430d-ac75-14a0983edf62";
            var title = "Updated title";
            var desc = "Update test description";
            var command = new UpdateProjectCommand()
            {
                Title = title,
                Description = desc,
                ProjectId = guid,
                Email = _email
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidEmptyTitle()
        {
            //arrange
            var handler = new UpdateProjectCommandHandler(_context);
            var guid = "d5212365-524a-430d-ac75-14a0983edf62";
            var title = "";
            var desc = "Update test description";
            var command = new UpdateProjectCommand()
            {
                Title = title,
                Description = desc,
                ProjectId = guid,
                Email = _email
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidEmptyDescription()
        {
            //arrange
            var handler = new UpdateProjectCommandHandler(_context);
            var guid = "d5212365-524a-430d-ac75-14a0983edf62";
            var title = "Updated title";
            var desc = "";
            var command = new UpdateProjectCommand()
            {
                Title = title,
                Description = desc,
                ProjectId = guid,
                Email = _email
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidEmptyStatus()
        {
            //arrange
            var handler = new UpdateProjectCommandHandler(_context);
            var guid = "d5212365-524a-430d-ac75-14a0983edf62";
            var title = "Updated title";
            var desc = "Updated description";
            var command = new UpdateProjectCommand()
            {
                Title = title,
                Description = desc,
                ProjectId = guid,
                Status = "",
                Email = _email
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidInvalidStatus()
        {
            //arrange
            var handler = new UpdateProjectCommandHandler(_context);
            var guid = "d5212365-524a-430d-ac75-14a0983edf62";
            var title = "Updated title";
            var desc = "Updated description";
            var command = new UpdateProjectCommand()
            {
                Title = title,
                Description = desc,
                ProjectId = guid,
                Status = "test",
                Email = _email
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldUpdateProjectAndSetStatusAsOpen()
        {
            //arrange
            var handler = new UpdateProjectCommandHandler(_context);
            var guid = "d5212365-524a-430d-ac75-14a0983edf62";
            var title = "Updated title";
            var desc = "Update test description";
            var command = new UpdateProjectCommand()
            {
                Title = title,
                Description = desc,
                ProjectId = guid,
                Status = "Open",
                Email = _email
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            var project = await (from p in _context.Projects
                                 where p.Id == new Guid(guid)
                                 select p).FirstOrDefaultAsync();
            project.Title.ShouldBe(title);
            project.Description.ShouldBe(desc);
            project.Status.ShouldBeOfType<ProjectStatus>();
            project.Status.ShouldBe(ProjectStatus.Open);
            project.Id.ShouldBe(new Guid(guid));
            project.ModifiedBy.ShouldBe(_email);
            project.Modified.ShouldBeInRange(DateTimeOffset.UtcNow.AddMinutes(-1), DateTimeOffset.UtcNow);
        }

        [Fact]
        public async Task ShouldUpdateProjectAndSetStatusAsClose()
        {
            //arrange
            var handler = new UpdateProjectCommandHandler(_context);
            var guid = "d5212365-524a-430d-ac75-14a0983edf62";
            var title = "Updated title";
            var desc = "Update test description";
            var command = new UpdateProjectCommand()
            {
                Title = title,
                Description = desc,
                ProjectId = guid,
                Status = "Close",
                Email = _email
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            var project = await (from p in _context.Projects
                                 where p.Id == new Guid(guid)
                                 select p).FirstOrDefaultAsync();
            project.Title.ShouldBe(title);
            project.Description.ShouldBe(desc);
            project.Status.ShouldBeOfType<ProjectStatus>();
            project.Status.ShouldBe(ProjectStatus.Close);
            project.Id.ShouldBe(new Guid(guid));
            project.ModifiedBy.ShouldBe(_email);
            project.Modified.ShouldBeInRange(DateTimeOffset.UtcNow.AddMinutes(-1), DateTimeOffset.UtcNow);
        }
    }
}
