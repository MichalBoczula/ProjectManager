using Application.Features.ManagerProjectAction.Queries.ProjectsList;
using AutoMapper;
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

namespace UnitTests.Features.ManagerProjectAction.Queries.ProjectsList
{
    [Collection("QueryCollection")]
    public class ProjectListForManagerQueryHandlerTest
    {
        private readonly ProjectManagerDbContext _context;
        private readonly IMapper _mapper;

        public ProjectListForManagerQueryHandlerTest(QueryTestBase testBase)
        {
            _context = testBase.Context;
            _mapper = testBase.Mapper;
        }

        [Fact]
        public async Task ShouldReturnList()
        {
            //arange
            var handler = new ProjectListForManagerQueryHandler(_context, _mapper);
            //act
            var result = await handler.Handle(
                new ProjectListForManagerQuery() { Email = "PaulAllen@email.com" },
                CancellationToken.None);
            //assert
            result.ShouldBeOfType<List<ProjectForManagersList>>();
            result.Count.ShouldBeGreaterThan<int>(0);
            foreach (var ele in result)
            {
                ele.Description.ShouldBeOfType<string>();
                ele.Description.ShouldNotBeNullOrWhiteSpace();
                ele.Title.ShouldBeOfType<string>();
                ele.Title.ShouldNotBeNullOrWhiteSpace();
                ele.Status.ShouldBeOfType<string>();
                ele.Status.ShouldNotBeNullOrWhiteSpace();
            }
        }

        [Fact]
        public async Task ShouldReturnNull()
        {
            //arange
            var handler = new ProjectListForManagerQueryHandler(_context, _mapper);
            //act
            var result = await handler.Handle(
                new ProjectListForManagerQuery() { Email = "test@email.com" },
                CancellationToken.None);
            //assert
            result.ShouldBeNull();
        }
    }
}
