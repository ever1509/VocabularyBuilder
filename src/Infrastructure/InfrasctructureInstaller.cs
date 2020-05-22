using Application.Common.Interfaces;
using Infrastructure.Data;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public static class InfrasctructureInstaller
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<VocabularyBuilderDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("VocabularyBuilderDatabase"),
                    b => b.MigrationsAssembly(typeof(VocabularyBuilderDbContext).Assembly.FullName)));

            services.AddScoped<IVocabularyBuilderDbContext>(provider => provider.GetService<VocabularyBuilderDbContext>());

            services.AddDefaultIdentity<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<VocabularyBuilderDbContext>();

            services.AddTransient<IIdentityService, IdentityService>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            return services;
        }
    }
}
