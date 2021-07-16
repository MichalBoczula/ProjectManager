using Application.Contracts.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Persistance.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.DependencyInjection
{
    public static class PersistanceDI
    {
        public static IServiceCollection AddPersistance(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProjectManagerDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("ProjectManagerConnection")));
            services.AddScoped<IProjectManagerDbContext, ProjectManagerDbContext>();
            return services;
        }
    }
}
