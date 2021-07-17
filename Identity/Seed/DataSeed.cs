using Identity.Data;
using Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Seed
{
    public static class DataSeed
    {
        public static async Task Seed(this ModelBuilder modelBuilder)
        {
            var services = new ServiceCollection();
            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var userMgr = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

                    var alice = new ApplicationUser()
                    {
                        UserName = "alice",
                        Email = "AliceSmith@email.com",
                        EmailConfirmed = true,
                    };

                   await userMgr.CreateAsync(alice, "Pass123$");

                    var bob = new ApplicationUser()
                    {
                        UserName = "bob",
                        Email = "BobSmith@email.com",
                        EmailConfirmed = true
                    };

                    await userMgr.CreateAsync(bob, "Pass123");
                }
            }
        }
    }
}
