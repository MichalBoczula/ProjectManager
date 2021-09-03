using Application.Features.ManagerProjectAction.Queries.ProjectActionWithFilter;
using AutoMapper;
using Domain.Entities;
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

namespace UnitTests.Features.ManagerProjectAction.Queries.ProjectActionWithFilter
{
    [Collection("QueryCollection")]
    public class ProjectActionWithFilterQueryHandlerTests
    {
        private readonly ProjectManagerDbContext _context;
        private readonly IMapper _mapper;

        public ProjectActionWithFilterQueryHandlerTests(QueryTestBase testBase)
        {
            _context = testBase.Context;
            _mapper = testBase.Mapper;
        }

        [Fact]
        public async Task ShouldReturnList()
        {
            //arrange
            var handler = new ProjectActionWithFilterQueryHandler(_context, _mapper);
            //act
            var result = await handler.Handle(new ProjectActionWithFilterQuery()
            {
                ActionStatus = ProgressStatus.ToDo.ToString(),
                ActionName = "Dom",
                Email = "PaulAllen@email.com",
                Skip = 0,
                Take = 0
            }, CancellationToken.None);
            //assert
            result.ShouldBeOfType<List<ProjectActionWithFilterVm>>();
            result.Count.ShouldBe(1);
            foreach(var projAction in result)
            {
                projAction.Project.Id.ShouldBeOfType<Guid>();
                projAction.Project.Title.ShouldNotBeNullOrWhiteSpace();
                projAction.Project.Description.ShouldNotBeNullOrWhiteSpace();
                projAction.ProjectActions.Count.ShouldBe(1);
                foreach (var ele in projAction.ProjectActions)
                {
                    ele.Id.ShouldBeOfType<Guid>();
                    ele.Title.ShouldNotBeNullOrWhiteSpace();
                    ele.Description.ShouldNotBeNullOrWhiteSpace();
                    ele.Status.ShouldNotBeNullOrWhiteSpace();
                }
            }
        }

        [Fact]
        public async Task ShouldReturnNullInvalidEmail()
        {
            //arrange
            var handler = new ProjectActionWithFilterQueryHandler(_context, _mapper);
            //act
            var result = await handler.Handle(new ProjectActionWithFilterQuery()
            {
                ActionStatus = ProgressStatus.ToDo.ToString(),
                ActionName = "Dom",
                Email = "test@email.com"
            }, CancellationToken.None);
            //assert
            result.ShouldBeNull();
        }

        [Fact]
        public async Task ShouldReturnEmptyList()
        {
            //arrange
            var handler = new ProjectActionWithFilterQueryHandler(_context, _mapper);
            //act
            var result = await handler.Handle(new ProjectActionWithFilterQuery()
            {
                ActionStatus = ProgressStatus.ToDo.ToString(),
                ActionName = "this is test for empty result list",
                Email = "PaulAllen@email.com"
            }, CancellationToken.None);
            //assert
            result.Count.ShouldBe(0);
        }

        [Fact]
        public async Task ShouldReturnTenRecordsInList()
        {
            //arrange
            var handler = new ProjectActionWithFilterQueryHandler(_context, _mapper);
            //act
            var result = await handler.Handle(new ProjectActionWithFilterQuery()
            {
                Email = "PaulAllen@email.com"
            }, CancellationToken.None);
            //assert
            result.ShouldBeOfType<List<ProjectActionWithFilterVm>>();
            result.Count.ShouldBe(10);
            foreach (var projAction in result)
            {
                projAction.Project.Id.ShouldBeOfType<Guid>();
                projAction.Project.Title.ShouldNotBeNullOrWhiteSpace();
                projAction.Project.Description.ShouldNotBeNullOrWhiteSpace();
                foreach (var ele in projAction.ProjectActions)
                {
                    ele.Id.ShouldBeOfType<Guid>();
                    ele.Title.ShouldNotBeNullOrWhiteSpace();
                    ele.Description.ShouldNotBeNullOrWhiteSpace();
                    ele.Status.ShouldNotBeNullOrWhiteSpace();
                }
            }
        }

        [Fact]
        public async Task ShouldReturnAllRecords()
        {
            //arrange
            var handler = new ProjectActionWithFilterQueryHandler(_context, _mapper);
            //act
            var result = await handler.Handle(new ProjectActionWithFilterQuery()
            {
                Email = "PaulAllen@email.com",
                Take = 0
            }, CancellationToken.None);
            //assert
            result.ShouldBeOfType<List<ProjectActionWithFilterVm>>();
            result.Count.ShouldBe(12);
            foreach (var projAction in result)
            {
                projAction.Project.Id.ShouldBeOfType<Guid>();
                projAction.Project.Title.ShouldNotBeNullOrWhiteSpace();
                projAction.Project.Description.ShouldNotBeNullOrWhiteSpace();
                foreach (var ele in projAction.ProjectActions)
                {
                    ele.Id.ShouldBeOfType<Guid>();
                    ele.Title.ShouldNotBeNullOrWhiteSpace();
                    ele.Description.ShouldNotBeNullOrWhiteSpace();
                    ele.Status.ShouldNotBeNullOrWhiteSpace();
                }
            }
        }

        [Fact]
        public async Task ShouldSkipFiveAndReturnSevenRecords()
        {
            //arrange
            var handler = new ProjectActionWithFilterQueryHandler(_context, _mapper);
            //act
            var result = await handler.Handle(new ProjectActionWithFilterQuery()
            {
                Email = "PaulAllen@email.com",
                Take = 0,
                Skip = 5
            }, CancellationToken.None);
            //assert
            result.ShouldBeOfType<List<ProjectActionWithFilterVm>>();
            result.Count.ShouldBe(7);
            foreach (var projAction in result)
            {
                projAction.Project.Id.ShouldBeOfType<Guid>();
                projAction.Project.Title.ShouldNotBeNullOrWhiteSpace();
                projAction.Project.Description.ShouldNotBeNullOrWhiteSpace();
                foreach (var ele in projAction.ProjectActions)
                {
                    ele.Id.ShouldBeOfType<Guid>();
                    ele.Title.ShouldNotBeNullOrWhiteSpace();
                    ele.Description.ShouldNotBeNullOrWhiteSpace();
                    ele.Status.ShouldNotBeNullOrWhiteSpace();
                }
            }
        }

        [Fact]
        public async Task ShouldSkipFiveAndReturnFiveRecords()
        {
            //arrange
            var handler = new ProjectActionWithFilterQueryHandler(_context, _mapper);
            //act
            var result = await handler.Handle(new ProjectActionWithFilterQuery()
            {
                Email = "PaulAllen@email.com",
                Take = 0,
                Skip = 5
            }, CancellationToken.None);
            //assert
            result.ShouldBeOfType<List<ProjectActionWithFilterVm>>();
            result.Count.ShouldBe(7);
            foreach (var projAction in result)
            {
                projAction.Project.Id.ShouldBeOfType<Guid>();
                projAction.Project.Title.ShouldNotBeNullOrWhiteSpace();
                projAction.Project.Description.ShouldNotBeNullOrWhiteSpace();
                foreach (var ele in projAction.ProjectActions)
                {
                    ele.Id.ShouldBeOfType<Guid>();
                    ele.Title.ShouldNotBeNullOrWhiteSpace();
                    ele.Description.ShouldNotBeNullOrWhiteSpace();
                    ele.Status.ShouldNotBeNullOrWhiteSpace();
                }
            }
        }

        [Fact]
        public async Task ShouldReturnOneRecord()
        {
            //arrange
            var handler = new ProjectActionWithFilterQueryHandler(_context, _mapper);
            //act
            var result = await handler.Handle(new ProjectActionWithFilterQuery()
            {
                Email = "PaulAllen@email.com",
                ActionStatus = ProgressStatus.ToCheck.ToString()
            }, CancellationToken.None);
            //assert
            result.ShouldBeOfType<List<ProjectActionWithFilterVm>>();
            result.Count.ShouldBe(1);
            foreach (var projAction in result)
            {
                projAction.Project.Id.ShouldBeOfType<Guid>();
                projAction.Project.Title.ShouldNotBeNullOrWhiteSpace();
                projAction.Project.Description.ShouldNotBeNullOrWhiteSpace();
                projAction.ProjectActions.Count.ShouldBe(1);
                foreach (var ele in projAction.ProjectActions)
                {
                    ele.Id.ShouldBeOfType<Guid>();
                    ele.Title.ShouldNotBeNullOrWhiteSpace();
                    ele.Description.ShouldNotBeNullOrWhiteSpace();
                    ele.Status.ShouldNotBeNullOrWhiteSpace();
                    ele.Status.ShouldBe(ProgressStatus.ToCheck.ToString());
                }
            }
        }
    }
}
