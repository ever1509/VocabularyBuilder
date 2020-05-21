using System;
using System.Linq;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace VocabularyBuilder.API.IntegrationTests.Base
{
    public class AppTestFixture:WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var descriptorContextVb = services.SingleOrDefault(d =>
                    d.ServiceType == typeof(DbContextOptions<VocabularyBuilderDbContext>));

                if (descriptorContextVb != null)
                {
                    services.Remove(descriptorContextVb);
                }

                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();

                services.AddDbContext<VocabularyBuilderDbContext>(options =>
                {
                    options.UseInMemoryDatabase("InMemoryVocabularyBuilderTest");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    using (var appContext = scope.ServiceProvider.GetRequiredService<VocabularyBuilderDbContext>())
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
