using Application.Contracts.Persistance;
using Application.Features.ForTraning;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Features
{
    public class RepositoryForTestingTest
    {
        [Fact]
        public void ShouldReturnList()
        {
            //arange
            var list = new List<Employee>()
            {
                new Employee
                {
                    FirstName = "Majk"
                },
                new Employee
                {
                    FirstName = "Junior"
                },
                new Employee
                {
                    FirstName = "Rawrrr"
                }
            };
            var mock = new Mock<IRepositoryForTesting>();
            mock.Setup(x => x.GetEmps()).Returns(list.AsQueryable());
            //act
            var result = mock.Object.GetEmps().Where(x => x.FirstName != "Rawrrr");
            //assert
            result.Count().ShouldBe(2);
        }


        public static DbSet<T> GetQueryableMockDbSet<T>(List<T> sourceList) where T : class
        {
            var queryable = sourceList.AsQueryable();
            var dbSet = new Mock<DbSet<T>>();
            dbSet.As<IQueryable<T>>().Setup(m => m.Provider).Returns(queryable.Provider);
            dbSet.As<IQueryable<T>>().Setup(m => m.Expression).Returns(queryable.Expression);
            dbSet.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(queryable.ElementType);
            dbSet.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(() => queryable.GetEnumerator());
            dbSet.Setup(d => d.Add(It.IsAny<T>())).Callback<T>((s) => sourceList.Add(s));
            return dbSet.Object;
        }


        [Fact]
        public void Setup()
        {
            //arrange
            var list = new List<Employee>()
            {
                new Employee
                {
                    FirstName = "Majk"
                },
                new Employee
                {
                    FirstName = "Junior"
                },
                new Employee
                {
                    FirstName = "Rawrrr"
                }
            };
            DbSet<Employee> emp = GetQueryableMockDbSet(list);
            var myDbMoq = new Mock<IProjectManagerDbContext>();
            myDbMoq.Setup(x => x.Employees).Returns(emp);
            //act
            var result = myDbMoq.Object.Employees.Where(x => x.FirstName != "Rawrrr");
            //assert
            result.Count().ShouldBe(2);
        }

    }
}
