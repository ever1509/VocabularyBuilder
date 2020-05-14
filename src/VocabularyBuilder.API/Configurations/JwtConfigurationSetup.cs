﻿using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using VocabularyBuilder.Infrastructure.Identity;

namespace VocabularyBuilder.API.Configurations
{
    public static class JwtConfigurationSetup
    {
        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services,
            IConfiguration configuration)
        {
            //For Jwt Configuration And Authentication Configuration---------------------------------------------------------------

            var jwtSettings = new JwtSettings();
            configuration.Bind(nameof(jwtSettings), jwtSettings);
            services.AddSingleton(jwtSettings);

            var tokenValidationParameters=
                    new TokenValidationParameters()
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes((jwtSettings.Secret))),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        RequireExpirationTime = false,
                        ValidateLifetime = true
                    };
            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.SaveToken = true;
                    options.TokenValidationParameters = tokenValidationParameters;

                });
            //For Jwt configuration End----------------------------------------------------------------------------------------------

            services.AddAuthorization();

            return services;
        }
    }
}
