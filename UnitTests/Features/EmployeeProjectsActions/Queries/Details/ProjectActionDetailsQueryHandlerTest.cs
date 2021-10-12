using Application.Features.Common.Exceptions;
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
            var email = "AdamKowalski@email.com";
            var guid = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            //act
            var result = await handler.Handle(
                    new ProjectActionDetailsQuery() 
                    {
                        ProjectActionId =  guid,
                        Email = email
                    },
                    cancellationToken: CancellationToken.None);
            //assert
            result.ShouldBeOfType<ProjectActionDetailsQueryResult>();
            result.AreThereException.ShouldBeFalse();
            result.ExceptionsList.Count.ShouldBe(0);
            result.Vm.ProjectActionDto.Status.ShouldNotBeNullOrWhiteSpace();
            result.Vm.ProjectActionDto.Title.ShouldNotBeNullOrWhiteSpace();
            result.Vm.ProjectActionDto.Description.ShouldNotBeNullOrWhiteSpace();
            result.Vm.ProjectActionDto.DeadLine.ShouldBeOfType<DateTimeOffset>();
            result.Vm.ProjectActionDto.Done.ShouldBeOfType<DateTimeOffset>();
            result.Vm.ProjectActionDto.Established.ShouldBeOfType<DateTimeOffset>();
            result.Vm.ManagerDto.FullName.ShouldNotBeNullOrWhiteSpace();
            result.Vm.ManagerDto.Email.ShouldNotBeNullOrWhiteSpace();
        }


        [Fact]
        public async Task ShouldReturnActionDoesntExistsException()
        {
            //arrange
            var handler = new ProjectActionDetailsQueryHandler(_context, _mapper);
            var email = "AdamKowalski@email.com";
            var guid = "21b21a7e-0000-4fa0-850f-0a22f48193dd";
            //act
            var result = await handler.Handle(
                    new ProjectActionDetailsQuery()
                    {
                        ProjectActionId = guid,
                        Email = email
                    },
                    cancellationToken: CancellationToken.None);
            //assert
            result.ShouldBeOfType<ProjectActionDetailsQueryResult>();
            result.AreThereException.ShouldBeTrue();
            result.ExceptionsList.Count.ShouldBe(1);
            result.ExceptionsList[0].ShouldBeOfType<ProjectActionDoesntExistsException>();
            result.ExceptionsList[0].Message.ShouldBe("Project Action doesn't exists, Please check GUID");
            result.Vm.ShouldBeNull();
        }

        [Fact]
        public async Task ShouldReturnProjectActionInvalidGuidException()
        {
            //arrange
            var handler = new ProjectActionDetailsQueryHandler(_context, _mapper);
            var email = "AdamKowalski@email.com";
            var guid = "aaaaa";
            //act
            var result = await handler.Handle(
                  new ProjectActionDetailsQuery()
                  {
                      ProjectActionId = guid,
                      Email = email
                  },
                  cancellationToken: CancellationToken.None);
            //assert
            result.ShouldBeOfType<ProjectActionDetailsQueryResult>();
            result.AreThereException.ShouldBeTrue();
            result.ExceptionsList.Count.ShouldBe(1);
            result.ExceptionsList[0].ShouldBeOfType<ProjectActionInvalidGuidException>();
            result.ExceptionsList[0].Message.ShouldBe("Invalid Project Action GUID, GUID has format 00000000-0000-0000-0000-000000000000, check, correct and send request again");
            result.Vm.ShouldBeNull();
        }

        [Fact]
        public async Task ShouldReturnEmployeeDoesntExists()
        {
            //arrange
            var handler = new ProjectActionDetailsQueryHandler(_context, _mapper);
            var email = "aaaaa@email.com";
            var guid = "21b21a7e-402f-4fa0-850f-0a22f48193dd";
            //act
            var result = await handler.Handle(
                  new ProjectActionDetailsQuery()
                  {
                      ProjectActionId = guid,
                      Email = email
                  },
                  cancellationToken: CancellationToken.None);
            //assert
            result.ShouldBeOfType<ProjectActionDetailsQueryResult>();
            result.AreThereException.ShouldBeTrue();
            result.ExceptionsList.Count.ShouldBe(1);
            result.ExceptionsList[0].ShouldBeOfType<EmployeeDoesntExistsException>();
            result.ExceptionsList[0].Message.ShouldBe("Employee doesn't exists, Please check EMAIL");
            result.Vm.ShouldBeNull();
        }

        [Fact]
        public async Task ShouldReturnEmployeeDoesntExistsAndProjectActionDoesntExistsExceptions()
        {
            //arrange
            var handler = new ProjectActionDetailsQueryHandler(_context, _mapper);
            var email = "aaaaa@email.com";
            var guid = "21b21a7e-0000-4fa0-850f-0a22f48193dd";
            //act
            var result = await handler.Handle(
                  new ProjectActionDetailsQuery()
                  {
                      ProjectActionId = guid,
                      Email = email
                  },
                  cancellationToken: CancellationToken.None);
            //assert
            result.ShouldBeOfType<ProjectActionDetailsQueryResult>();
            result.AreThereException.ShouldBeTrue();
            result.ExceptionsList.Count.ShouldBe(2);
            result.ExceptionsList[0].ShouldBeOfType<ProjectActionDoesntExistsException>();
            result.ExceptionsList[0].Message.ShouldBe("Project Action doesn't exists, Please check GUID");
            result.ExceptionsList[1].ShouldBeOfType<EmployeeDoesntExistsException>();
            result.ExceptionsList[1].Message.ShouldBe("Employee doesn't exists, Please check EMAIL");
            result.Vm.ShouldBeNull();
        }
    }
}
