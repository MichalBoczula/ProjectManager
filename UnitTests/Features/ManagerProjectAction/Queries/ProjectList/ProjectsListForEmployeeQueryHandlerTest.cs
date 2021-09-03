using Application.Features.EmployeeProjectsActions.Queries.List;
using Application.Features.ManagerProjectAction.Queries.ProjectDetails;
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

namespace UnitTests.Features.ManagerProjectAction.Queries.ProjectList
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
            //arange
            var handler = new ManagerProjectDetailsQueryHandler(_context, _mapper);
            var firstProjectGuid = "d5212365-524a-430d-ac75-14a0983edf62";
            var Email = "PaulAllen@email.com";
            //act
            var result = await handler.Handle(
                new ManagerProjectDetailsQuery() 
                { 
                    ProjectId = firstProjectGuid,
                    Email = Email 
                },
                CancellationToken.None);
            //assert
            result.ShouldBeOfType<ProjectDetailsForManagersVm>();
            foreach(var ele in result.ProjectActions)
            {
                ele.DeadLine.ShouldBeOfType<DateTimeOffset>();
                ele.Description.ShouldBeOfType<string>();
                ele.Description.ShouldNotBeNullOrWhiteSpace();
                ele.Title.ShouldBeOfType<string>();
                ele.Title.ShouldNotBeNullOrWhiteSpace();
                ele.Status.ShouldBeOfType<string>();
                ele.Status.ShouldNotBeNullOrWhiteSpace();
                ele.Employee.FullName.ShouldBeOfType<string>();
                ele.Employee.FullName.ShouldNotBeNullOrWhiteSpace();
                ele.Employee.Email.ShouldBeOfType<string>();
                ele.Employee.Email.ShouldNotBeNullOrWhiteSpace();
            }
        }

        [Fact]
        public async Task ShouldReturnNullInvalidEmail()
        {
            //arange
            var handler = new ManagerProjectDetailsQueryHandler(_context, _mapper);
            var firstProjectGuid = "d5212365-524a-430d-ac75-14a0983edf62";
            var Email = "test@email.com";
            //act
            var result = await handler.Handle(
                new ManagerProjectDetailsQuery()
                {
                    ProjectId = firstProjectGuid,
                    Email = Email
                },
                CancellationToken.None);
            //assert
            result.ShouldBeNull();
        }

        [Fact]
        public async Task ShouldReturnNullInvalidProjectId()
        {
            //arange
            var handler = new ManagerProjectDetailsQueryHandler(_context, _mapper);
            var firstProjectGuid = "d5212365-0000-0000-ac75-14a0983edf62";
            var Email = "PaulAllen@email.com";
            //act
            var result = await handler.Handle(
                new ManagerProjectDetailsQuery()
                {
                    ProjectId = firstProjectGuid,
                    Email = Email
                },
                CancellationToken.None);
            //assert
            result.ShouldBeNull();
        }
    }
}
