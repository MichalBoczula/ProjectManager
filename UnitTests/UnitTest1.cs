using Application.Features.Projects.Queries;
using AutoMapper;
using Persistance.Context;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnitTests.Common;
using Xunit;

namespace UnitTests
{
    [Collection("QueryCollection")]
    public class UnitTest1
    {
        private readonly ProjectManagerDbContext _context;
        private readonly IMapper _mapper;

        public UnitTest1(QueryTestBase testBase)
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
                    new ProjectsListForEmployeeQuery() { Email = "AdamKowalski@email.com" },
                    cancellationToken: CancellationToken.None);
            //assert
            result.ShouldBeOfType<List<ProjectVm>>();
        }
    }
}
