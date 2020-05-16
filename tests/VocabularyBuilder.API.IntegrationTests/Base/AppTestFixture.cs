using System;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
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

                    }
                }
            });
        }
    }
}
