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
        public AcceptActionAfterCheckCommandHandlerTest()
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
        public async Task ShouldChangeStatusToDone()
        {
            //arrange
            var handler = new AcceptActionAfterCheckCommandHandler(_context);
            var guid = new Guid("21b21a7e-402f-4fa0-850f-0a22f48193dd");
            //act
            var result = await handler.Handle(new AcceptActionAfterCheckCommand() { ProjectActionId = guid },
                                              CancellationToken.None);
            //assert
            result.ShouldBeOfType<Guid>();
            result.ShouldBe(guid);
            var action = await (from pa in _context.ProjectActions
                                where pa.Id == guid
                                select pa).FirstOrDefaultAsync();
            action.ModifiedBy.ShouldBe("PaulAllen@email.com");
            action.Status.ShouldBe(ProgressStatus.Done);
        }
    }
}
