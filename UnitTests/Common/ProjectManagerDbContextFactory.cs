using Microsoft.EntityFrameworkCore;
using Moq;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTests.Common
{
    public static class ProjectManagerDbContextFactory
    {
        public static Mock<ProjectManagerDbContext> Create()
        {
            var options = new DbContextOptionsBuilder<ProjectManagerDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            var mock = new Mock<ProjectManagerDbContext>(options) { CallBase = true };
            var context = mock.Object;
            context.Database.EnsureCreated();
            context.SaveChanges();
            return mock;
        }

        public static void Destroy(ProjectManagerDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
