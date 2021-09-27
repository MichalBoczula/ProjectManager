using Application.Contracts.Identity;
using Application.Features.ManagerProjectAction.Commands.UpdateActionInProject;
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

namespace UnitTests.Features.ManagerProjectAction.Commands
{
    [Collection("CommandCollection")]
    public class UpdateActionCommandHandlerTest
    {
        private readonly ProjectManagerDbContext _context;
        private const string _email = "PaulAllen@email.com";

        public UpdateActionCommandHandlerTest()
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
        public async Task ShouldReturnEmptyGuidInvalidGuid()
        {
            //arrange
            var handle = new UpdateActionCommandHandler(_context);
            var guid = "aaaaa";
            var title = "Up title";
            var desc = "Up desc";
            var date = "15/09/21 08:45:00 +1:00";
            var command = new UpdateActionCommand()
            {
                Id = guid,
                Title = title,
                Description = desc,
                DeadLine = date
            };
            //act
            var result = await handle.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidInvalidDate()
        {
            //arrange
            var handle = new UpdateActionCommandHandler(_context);
            var guid = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            var title = "Up title";
            var desc = "Up desc";
            var date = "aaaaa";
            var command = new UpdateActionCommand()
            {
                Id = guid,
                Title = title,
                Description = desc,
                DeadLine = date
            };
            //act
            var result = await handle.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidInvalidEmptyTitle()
        {
            //arrange
            var handle = new UpdateActionCommandHandler(_context);
            var guid = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            var title = "";
            var desc = "Up desc";
            var date = "15/09/21 08:45:00 +1:00";
            var command = new UpdateActionCommand()
            {
                Id = guid,
                Title = title,
                Description = desc,
                DeadLine = date
            };
            //act
            var result = await handle.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidInvalidEmptyDescription()
        {
            //arrange
            var handle = new UpdateActionCommandHandler(_context);
            var guid = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            var title = "Up title";
            var desc = "";
            var date = "15/09/21 08:45:00 +1:00";
            var command = new UpdateActionCommand()
            {
                Id = guid,
                Title = title,
                Description = desc,
                DeadLine = date
            };
            //act
            var result = await handle.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidActionDoesntExists()
        {
            //arrange
            var handle = new UpdateActionCommandHandler(_context);
            var guid = "21b21a7e-402f-aaaa-850f-0a22f48193dd";
            var title = "Up title";
            var desc = "Up desc";
            var date = "15/09/21 08:45:00 +1:00";
            var command = new UpdateActionCommand()
            {
                Id = guid,
                Title = title,
                Description = desc,
                DeadLine = date
            };
            //act
            var result = await handle.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldUpdateAction()
        {
            //arrange
            var handle = new UpdateActionCommandHandler(_context);
            var guid = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            var title = "Up title";
            var desc = "Up desc";
            var date = "15/09/21 08:45:00 +1:00";
            var command = new UpdateActionCommand()
            {
                Id = guid,
                Title = title,
                Description = desc,
                DeadLine = date
            };
            //act
            var result = await handle.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(new Guid(guid));
            var action = await (from pa in _context.ProjectActions
                                where pa.Id == new Guid(guid)
                                select pa).FirstOrDefaultAsync();
            action.Title.ShouldBe(title);
            action.Description.ShouldBe(desc);
            action.DeadLine.ShouldBe(DateTimeOffset.Parse(date));
            action.ModifiedBy.ShouldBe("PaulAllen@email.com");
            action.Modified.ShouldBeInRange(DateTimeOffset.UtcNow.AddSeconds(-10), DateTimeOffset.UtcNow);
        }
    }
}
