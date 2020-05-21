using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Interfaces;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrastructureInstaller
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<VocabularyBuilderDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("VocabularyBuilderDatabase"),
                    b => b.MigrationsAssembly(typeof(VocabularyBuilderDbContext).Assembly.FullName)));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<VocabularyBuilderDbContext>();

            services.AddTransient<IIdentityService, IdentityService>();

            return services;
        }
    }
}
