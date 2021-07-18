using Application.Contracts.Persistance;
using Application.Profiles;
using AutoMapper;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace UnitTests.Common
{
    public class QueryTestBase : IDisposable
    {
        public ProjectManagerDbContext Context { get; private set; }
        public IMapper Mapper { get; private set; }

        public QueryTestBase()
        {
            Context = ProjectManagerDbContextFactory.Create().Object;

            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            Mapper = configurationProvider.CreateMapper();
        }

        public void Dispose()
        {
            ProjectManagerDbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestBase>
    {
    }
}