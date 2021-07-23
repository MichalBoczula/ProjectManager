using Application.Features.ProjectsActions.Queries.List;
using AutoMapper;
using Domain.Entities;
using Persistance.Context;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnitTests.Common;
using Xunit;

namespace UnitTests.Features.Projects.Queries.ProjectsActions.List
{
    [Collection("QueryCollection")]
    public class ProjectsListForEmployeeQueryHandlerTest
    {
        private readonly ProjectManagerDbContext _context;
        private readonly IMapper _mapper;

        public ProjectsListForEmployeeQueryHandlerTest(QueryTestBase testBase)
        {
            _context = testBase.Context;
            _mapper = testBase.Mapper;
        }

        [Fact]
        public async Task ShouldReturnList()
        {
            //arrange
            var handler = new ProjectsListForEmployeeQueryHandler(_context, _mapper);
            //act
            var result = await handler.Handle(
                    new ProjectsListForEmployeeQuery() { Email = "TomaszNowak@email.com" },
                    cancellationToken: CancellationToken.None);
            //assert
            result.ShouldBeOfType<List<ProjectVm>>();
            foreach(var ele in result)
            {
                ele.Project.Description.ShouldNotBeNullOrWhiteSpace();
                ele.Project.Title.ShouldNotBeNullOrWhiteSpace();
                ele.Project.Status.ShouldNotBeNullOrWhiteSpace();
                ele.ProjectActions.Count.ShouldBeGreaterThan(0);
                foreach(var action in ele.ProjectActions)
                {
                    action.Status.ShouldNotBeNullOrWhiteSpace();
                    action.Title.ShouldNotBeNullOrWhiteSpace();
                    action.Description.ShouldNotBeNullOrWhiteSpace();
                    action.DeadLine.ShouldBeOfType<DateTimeOffset>();
                    action.Done.ShouldBeOfType<DateTimeOffset>();
                    action.Established.ShouldBeOfType<DateTimeOffset>();
                }
            }
        }
    }
}
