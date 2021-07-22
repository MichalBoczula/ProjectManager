using Application.Features.Projects.Queries;
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
                    new ProjectsListForEmployeeQuery() { Email = "TomaszNowak@email.com" },
                    cancellationToken: CancellationToken.None);
            //assert
            result.ShouldBeOfType<List<ProjectVm>>();
        }


        [Fact]
        public async Task test()
        {
            var EmpId = from e in _context.Employees
                        where e.Email == "TomaszNowak@email.com"
                        select e.Id;
            var q = (from pa in _context.ProjectActions.AsEnumerable()
                        where pa.EmployeeId == EmpId.FirstOrDefault()
                     group pa by pa.ProjectId into x
                     select new
                     {
                         x.Key,
                         str = x.AsEnumerable<ProjectAction>()
                     }).ToList();

            System.Console.WriteLine();
        }
    }

    class Students
    {
        public string StuName { get; set; }
        public int GrPoint { get; set; }
        public int StuId { get; set; }

        public List<Students> GtStuRec()
        {
            List<Students> stulist = new List<Students>();
            stulist.Add(new Students { StuId = 1, StuName = " Joseph ", GrPoint = 800 });
            stulist.Add(new Students { StuId = 2, StuName = "Alex", GrPoint = 458 });
            stulist.Add(new Students { StuId = 3, StuName = "Harris", GrPoint = 900 });
            stulist.Add(new Students { StuId = 4, StuName = "Taylor", GrPoint = 900 });
            stulist.Add(new Students { StuId = 5, StuName = "Smith", GrPoint = 458 });
            stulist.Add(new Students { StuId = 6, StuName = "Natasa", GrPoint = 700 });
            stulist.Add(new Students { StuId = 7, StuName = "David", GrPoint = 750 });
            stulist.Add(new Students { StuId = 8, StuName = "Harry", GrPoint = 700 });
            stulist.Add(new Students { StuId = 9, StuName = "Nicolash", GrPoint = 597 });
            stulist.Add(new Students { StuId = 10, StuName = "Jenny", GrPoint = 750 });
            return stulist;
        }
    }
}
