using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.VisualBasic;
using VocabularyBuilder.API.Configurations;

namespace VocabularyBuilder.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowVocabularyBuilderApp",
                    builder => builder.WithOrigins("https://localhost:44304"));
            });

            services.AddControllers();

            var contact= new OpenApiContact()
            {
                Name= "Ever Orellana",
                Email = "ever1509@gmail.com",
                Url = new Uri("https://github.com/ever1509")
            };

            var license= new OpenApiLicense()
            {
                Name = "Vocabulary Builder License App",
                Url = new Uri("https://www.vocabularybuilder.com")
            };

            var info = new OpenApiInfo()
            {
                Version = "v1",
                Title = "Vocabulary Builder API",
                Description="API which handle the information related to improve vocabulary with an language idiom",
                TermsOfService = new Uri("https://www.vocabularybuilder.com/terms/"),
                Contact = contact,
                License = license
            };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("VocabularyBuilderAPI",info);
                c.ResolveConflictingActions(apiDescriptions=>apiDescriptions.First());
            });

            services.AddDatabaseSeup(Configuration);
            services.AddApplicationSetup();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseCors("AllowVocabularyBuilderApp");

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/VocabularyBuilderAPI/swagger.json", "Vocabulary Builder API v1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
