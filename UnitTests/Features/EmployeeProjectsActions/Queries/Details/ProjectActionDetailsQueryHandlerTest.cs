using Application.Features.EmployeeProjectsActions.Queries.Details;
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

namespace UnitTests.Features.EmployeeProjectsActions.Queries.Details
{
    [Collection("QueryCollection")]
    public class ProjectActionDetailsQueryHandlerTest
    {
        private readonly ProjectManagerDbContext _context;
        private readonly IMapper _mapper;

        public ProjectActionDetailsQueryHandlerTest(QueryTestBase testBase)
        {
            _context = testBase.Context;
            _mapper = testBase.Mapper;
        }

        [Fact]
        public async Task ShouldReturnDetails()
        {
            //arrange
            var handler = new ProjectActionDetailsQueryHandler(_context, _mapper);
            //act
            var result = await handler.Handle(
                    new ProjectActionDetailsQuery() { ProjectActionId = new Guid("21b21a7e-402f-4fa0-850f-0a22f48193dd") },
                    cancellationToken: CancellationToken.None);
            //assert
            result.ShouldBeOfType<ProjectActionDetailsVm>();
            result.ProjectActionDto.Status.ShouldNotBeNullOrWhiteSpace();
            result.ProjectActionDto.Title.ShouldNotBeNullOrWhiteSpace();
            result.ProjectActionDto.Description.ShouldNotBeNullOrWhiteSpace();
            result.ProjectActionDto.DeadLine.ShouldBeOfType<DateTimeOffset>();
            result.ProjectActionDto.Done.ShouldBeOfType<DateTimeOffset>();
            result.ProjectActionDto.Established.ShouldBeOfType<DateTimeOffset>();
            result.ManagerDto.FullName.ShouldNotBeNullOrWhiteSpace();
            result.ManagerDto.Email.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
