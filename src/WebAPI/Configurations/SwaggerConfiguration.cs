using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace WebAPI.Configurations
{
    public static class SwaggerConfiguration
    {
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services)
        {
            var contact = new OpenApiContact()
            {
                Name = "Ever Orellana",
                Email = "ever1509@gmail.com",
                Url = new Uri("https://github.com/ever1509")
            };

            var license = new OpenApiLicense()
            {
                Name = "Vocabulary Builder License App",
                Url = new Uri("https://www.vocabularybuilder.com")
            };

            var info = new OpenApiInfo()
            {
                Version = "v1",
                Title = "Vocabulary Builder API",
                Description = "API which handle the information related to improve vocabulary with an language idiom",
                TermsOfService = new Uri("https://www.vocabularybuilder.com/terms/"),
                Contact = contact,
                License = license
            };

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("VocabularyBuilderAPI", info);
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());

                //Adding configuration of jwt for swagger UI ----------------------------------

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = @"JWT Authorization header using the Bearer scheme. 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      Example: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }},
                        new List<string>()
                    }
                });
                //----------------------------------------

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            return services;
        }
    }
}
