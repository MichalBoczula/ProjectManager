using Application.Contracts.Identity;
using Application.Features.ManagerProjectAction.Commands.EvaluateProjectAction;
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

namespace UnitTests.Features.ManagerProjectAction.Commands.EvaluateProjectAction
{
    [Collection("CommandCollection")]
    public class EvaluateProjectActionCommandHandlerTests
    {
        private readonly ProjectManagerDbContext _context;
        private const string _email = "PaulAllen@email.com";

        public EvaluateProjectActionCommandHandlerTests()
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
            var handler = new EvaluateProjectActionCommandHandler(_context);
            var testId = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            var feedback = "everything is ok";
            var command = new EvaluateProjectActionCommand()
            {
                Email = _email,
                IsAccepted = true,
                ProjectActionId = testId,
                Feedback = feedback
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ToString().ShouldBe(testId);
            var project = await (from pa in _context.ProjectActions
                                 where pa.Id == new Guid(testId)
                                 select pa).FirstOrDefaultAsync(CancellationToken.None);
            project.Feedback.ShouldBe(feedback);
            project.ModifiedBy.ShouldBe(_email);
            project.Modified.ShouldBeInRange(DateTimeOffset.UtcNow.AddMinutes(-1), DateTimeOffset.UtcNow);
            project.Status.ShouldBe(ProgressStatus.Done);
        }

        [Fact]
        public async Task ShouldChangeStatusToImprove()
        {
            //arrange
            var handler = new EvaluateProjectActionCommandHandler(_context);
            var testId = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            var feedback = "some mistakes";
            var command = new EvaluateProjectActionCommand()
            {
                Email = _email,
                IsAccepted = false,
                ProjectActionId = testId,
                Feedback = feedback
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ToString().ShouldBe(testId);
            var project = await (from pa in _context.ProjectActions
                                 where pa.Id == new Guid(testId)
                                 select pa).FirstOrDefaultAsync(CancellationToken.None);
            project.Feedback.ShouldBe(feedback);
            project.ModifiedBy.ShouldBe(_email);
            project.Modified.ShouldBeInRange(DateTimeOffset.UtcNow.AddMinutes(-1), DateTimeOffset.UtcNow);
            project.Status.ShouldBe(ProgressStatus.ToImprove);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidInvalidActionId()
        {
            //arrange
            var handler = new EvaluateProjectActionCommandHandler(_context);
            var testId = "21b21a7e-0000-0000-0000-0a22f48193dd";
            var feedback = "some mistakes";
            var command = new EvaluateProjectActionCommand()
            {
                Email = _email,
                IsAccepted = false,
                ProjectActionId = testId,
                Feedback = feedback
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidInvalidEmail()
        {
            //arrange
            var handler = new EvaluateProjectActionCommandHandler(_context);
            var testId = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            var feedback = "some mistakes";
            var command = new EvaluateProjectActionCommand()
            {
                Email = "test@email.com",
                IsAccepted = false,
                ProjectActionId = testId,
                Feedback = feedback
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidIsAcceptedIsNull()
        {
            //arrange
            var handler = new EvaluateProjectActionCommandHandler(_context);
            var testId = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            var feedback = "some mistakes";
            var command = new EvaluateProjectActionCommand()
            {
                Email = _email,
                IsAccepted = null,
                ProjectActionId = testId,
                Feedback = feedback
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(Guid.Empty);
        }

        [Fact]
        public async Task ShouldReturnEmptyGuidInvalidGuid()
        {
            //arrange
            var handler = new EvaluateProjectActionCommandHandler(_context);
            var testId = "aaaaa";
            var feedback = "some mistakes";
            var command = new EvaluateProjectActionCommand()
            {
                Email = _email,
                IsAccepted = null,
                ProjectActionId = testId,
                Feedback = feedback
            };
            //act
            var result = await handler.Handle(command, CancellationToken.None);
            //assert
            result.ShouldBe(Guid.Empty);
        }
    }
}
