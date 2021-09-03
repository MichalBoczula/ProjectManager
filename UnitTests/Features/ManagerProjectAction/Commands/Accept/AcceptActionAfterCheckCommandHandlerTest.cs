using Application.Contracts.Identity;
using Application.Contracts.Persistance;
using Application.Features.ManagerProjectAction.Commands.Accept;
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
using UnitTests.Common;
using Xunit;

namespace UnitTests.Features.ManagerProjectAction.Commands.Accept
{
    [Collection("CommandCollection")]
    public class AcceptActionAfterCheckCommandHandlerTest
    {
        private readonly ProjectManagerDbContext _context;
        private const string _email = "PaulAllen@email.com";
        public AcceptActionAfterCheckCommandHandlerTest()
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
        public async Task ShouldChangeStatusToDone()
        {
            //arrange
            var handler = new AcceptActionAfterCheckCommandHandler(_context);
            var guid = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            var command = new AcceptActionAfterCheckCommand()
            {
                ProjectActionId = guid,
                Email = "PaulAllen@email.com"
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            var action = await (from pa in _context.ProjectActions
                                where pa.Id == new Guid(guid)
                                select pa).FirstOrDefaultAsync();
            action.Id.ShouldBe(new Guid(guid));
            action.ModifiedBy.ShouldBe(_email);
            action.Modified.ShouldBeInRange(DateTimeOffset.Now.AddMinutes(-1), DateTimeOffset.Now);
            action.Done.ShouldBeInRange(DateTimeOffset.Now.AddMinutes(-1), DateTimeOffset.Now);
            action.Status.ShouldBe(ProgressStatus.Done);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidInvalidEmail()
        {
            //arrange
            var handler = new AcceptActionAfterCheckCommandHandler(_context);
            var guid = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            var command = new AcceptActionAfterCheckCommand()
            {
                ProjectActionId = guid,
                Email = "test@email.com"
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
            var handler = new AcceptActionAfterCheckCommandHandler(_context);
            var guid = "21b21a7e-0000-0000-850f-0a22f48193dd";
            var command = new AcceptActionAfterCheckCommand()
            {
                ProjectActionId = guid,
                Email = "PaulAllen@email.com"
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }
    }
}
