using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
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


            //For Jwt Configuration And Authentication Configuration---------------------------------------------------------------

            var jwtSettings = new JwtSettings();
            Configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes((jwtSettings.Secret))),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false,
                        ValidateLifetime = true
                    };
                });

            //For Jwt configuration End----------------------------------------------------------------------------------------------

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

                //Adding configuration of jwt for swagger UI ----------------------------------

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name ="Authorization",
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
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,

                        },
                        new List<string>()
                    }
                });
                //----------------------------------------
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

            app.UseAuthentication();

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
