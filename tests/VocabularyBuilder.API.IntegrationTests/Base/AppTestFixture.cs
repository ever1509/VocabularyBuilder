using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using VocabularyBuilder.Data;
using VocabularyBuilder.Infrastructure.Identity;

namespace VocabularyBuilder.API.IntegrationTests.Base
{
    public class AppTestFixture:WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {

                var descriptorContextVb = services.SingleOrDefault(d =>
                    d.ServiceType == typeof(DbContextOptions<VocabularyBuilderContext>));

                var descriptorContextAc =
                    services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationDbContext>));

                if (descriptorContextVb != null && descriptorContextAc != null)
                {
                    services.Remove(descriptorContextVb);
                    services.Remove(descriptorContextAc);
                }

                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<VocabularyBuilderContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryVocabularyBuilderTest");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    using (var appContext = scope.ServiceProvider.GetRequiredService<VocabularyBuilderContext>())
                    {
                        try
                        {
                            appContext.Database.EnsureCreated();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }
                    }
                }

                services.AddDbContext<ApplicationDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryApplicationDbContextTest");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var spApplicationDbContext = services.BuildServiceProvider();

                using (var scope = spApplicationDbContext.CreateScope())
                {
                    using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                    {
                        try
                        {
                            appContext.Database.EnsureCreated();
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e);
                            throw;
                        }

                        InitializeSeedData(appContext);
                    }
                }
            });

        }

        private void InitializeSeedData(ApplicationDbContext appContext)
        {
            appContext.Roles.AddRange(testRolesList());
            appContext.Users.AddRange(testUserList());
            appContext.UserRoles.AddRange(testUserRoles());

            appContext.SaveChanges();
        }

        private List<IdentityUserRole<string>> testUserRoles()
        {
            return new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>(){RoleId = TestUsersSettings.AdminRole,UserId = TestUsersSettings.AdminId},
                new IdentityUserRole<string>(){RoleId = TestUsersSettings.UserRole,UserId = TestUsersSettings.UserId}
            };
        }

        private List<IdentityRole> testRolesList()
        {
            return new List<IdentityRole>()
            {
                new IdentityRole() {Name = TestUsersSettings.AdminRole, Id = TestUsersSettings.AdminRole},
                new IdentityRole() {Name = TestUsersSettings.UserRole, Id = TestUsersSettings.UserRole}
            };
        }
        public List<ApplicationUser> testUserList()
        {
            return new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    Id = TestUsersSettings.AdminId,
                    Email = TestUsersSettings.AdminEmail,
                    PasswordHash = Guid.NewGuid().ToString(),
                    UserName = TestUsersSettings.AdminName
                },
                new ApplicationUser()
                {
                    Id = TestUsersSettings.UserId,
                    Email = TestUsersSettings.UserEmail,
                    PasswordHash = Guid.NewGuid().ToString(),
                    UserName = TestUsersSettings.UserName
                },
                new ApplicationUser()
                {
                    Id = TestUsersSettings.SpecialId,
                    Email = TestUsersSettings.SpecialEmail,
                    UserName = TestUsersSettings.SpecialName,
                    PasswordHash = Guid.NewGuid().ToString()
                }
            };
        }
    }
}
