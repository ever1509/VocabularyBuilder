using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using VocabularyBuilder.Data;

namespace VocabularyBuilder.API.Configurations
{
    public static class DatabaseSetup
    {
        public static void AddDatabaseSeup(this IServiceCollection services, IConfiguration configuration)
        {
            if(services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<VocabularyBuilderContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("VocabularyBuilderDatabase")));


        }
    }
}
