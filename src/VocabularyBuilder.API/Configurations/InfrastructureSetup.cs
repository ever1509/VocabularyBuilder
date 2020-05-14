﻿using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VocabularyBuilder.Infrastructure.Identity;

namespace VocabularyBuilder.API.Configurations
{
    public static class InfrastructureSetup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("VocabularyBuilderDatabase")));

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IIdentityService, IdentityService>();
            //TODO: Create variable environment to handle injections for tests condition

            // services.AddIdentityServer().AddApiAuthorization<ApplicationUser, ApplicationDbContext>();


            return services;
        }
    }
}
