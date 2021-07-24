using Application.Contracts.Identity;
using Application.Features.ManagerProjectAction.Commands.ToImprove;
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

namespace UnitTests.Features.ManagerProjectAction.Commands.ToImprove
{
    [Collection("CommandCollection")]
    public class SendActionToImproveCommandHandlerTest
    {
        private readonly ProjectManagerDbContext _context;

        public SendActionToImproveCommandHandlerTest()
        {
            var mockUserService = new Mock<ICurrentUserService>();
            mockUserService.Setup(x => x.Email).Returns("PaulAllen@email.com");
            var options = new DbContextOptionsBuilder<ProjectManagerDbContext>()
               .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var _contextMock = new Mock<ProjectManagerDbContext>(options, mockUserService.Object) { CallBase = true };
            _context = _contextMock.Object;
            _context.Database.EnsureCreated();
            _context.SaveChanges();
        }

        [Fact]
        public async Task ShouldChangeStatusToToImprove()
        {
            //arrange
            var handler = new SendActionToImproveCommandHandler(_context);
            var guid = new Guid("21b21a7e-402f-4fa0-850f-0a22f48193dd");
            var feedback = "Make any test feedback";
            //act
            var result = await handler.Handle(
                new SendActionToImproveCommand() { ProjectActionId = guid, Feedback = feedback },
                CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(guid);
            var action = await (from pa in _context.ProjectActions
                                where pa.Id == guid
                                select pa).FirstOrDefaultAsync();
            action.Status.ShouldBe(ProgressStatus.ToImprove);
            action.Feedback.ShouldBe(feedback);
            action.ModifiedBy.ShouldBe("PaulAllen@email.com");
        }
    }
}
