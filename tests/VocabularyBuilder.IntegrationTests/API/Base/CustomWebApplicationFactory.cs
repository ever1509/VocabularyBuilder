using System;
using System.Linq;
using Application.Common.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace VocabularyBuilder.IntegrationTests.API.Base
{
    public class CustomWebApplicationFactory<TStartup>:WebApplicationFactory<TStartup> where TStartup:class
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
                    options.UseInMemoryDatabase("InMemoryDbForTesting");
                    options.UseInternalServiceProvider(serviceProvider);
                });

                services.AddScoped<IVocabularyBuilderDbContext>(provider =>
                    provider.GetService<VocabularyBuilderDbContext>());

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var dbContext = scopedServices.GetRequiredService<VocabularyBuilderDbContext>();
                    var logger = scopedServices.GetRequiredService<ILogger<CustomWebApplicationFactory<TStartup>>>();

                    dbContext.Database.EnsureCreated();

                    try
                    {
                        Utilities.InitSeedDataFromTestDb(dbContext);
                    }
                    catch (Exception e)
                    {
                        logger.LogError(e,$"An Error occurred seeding the database with test message. Error: {e.Message}");
                    }
                }

            });
        }
    }
}
