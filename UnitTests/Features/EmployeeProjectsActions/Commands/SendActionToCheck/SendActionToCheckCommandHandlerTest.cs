using Application.Contracts.Identity;
using Application.Features.EmployeeProjectsActions.Commands.SendActionToCheck;
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

namespace UnitTests.Features.EmployeeProjectsActions.Commands.SendActionToCheck
{
    [Collection("CommandCollection")]
    public class SendActionToCheckCommandHandlerTest
    {
        private readonly ProjectManagerDbContext _context;
        private const string _email = "TomaszNowak@email.com";

        public SendActionToCheckCommandHandlerTest()
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
        public async Task ShouldChangeStatusToCheck()
        {
            //arrange
            var handler = new SendActionToCheckCommandHandler(_context);
            var guid = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            //act
            var result = await handler.Handle(new SendActionToCheckCommand() { ProjectActionId = guid },
                 cancellationToken: CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            var action = await (from pa in _context.ProjectActions
                                where pa.Id == new Guid(guid)
                                select pa).FirstOrDefaultAsync();
            action.Id.ShouldBe(new Guid(guid));
            action.Status.ShouldBe(ProgressStatus.ToCheck);
            action.ModifiedBy.ShouldBe(_email);
            action.Modified.ShouldBeInRange(DateTimeOffset.Now.AddMinutes(-1), DateTimeOffset.Now);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuid()
        {
            //arrange
            var handler = new SendActionToCheckCommandHandler(_context);
            var guid = "21b21a7e-0000-0000-850f-0a22f48193dd";
            //act
            var result = await handler.Handle(new SendActionToCheckCommand() { ProjectActionId = guid },
                 cancellationToken: CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(Guid.Empty);
        }
    }
}
