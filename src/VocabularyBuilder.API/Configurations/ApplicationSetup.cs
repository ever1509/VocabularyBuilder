using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using VocabularyBuilder.Application.Categories.Queries.GetCategories;
using VocabularyBuilder.Application.Common.Behaviours;
using VocabularyBuilder.Application.Common.Mappings;
using VocabularyBuilder.Application.FlashCards.Commands.AddFlashCard;
using VocabularyBuilder.Application.FlashCards.Commands.DeleteFlashCard;
using VocabularyBuilder.Application.FlashCards.Commands.UpdateFlashCard;
using VocabularyBuilder.Application.FlashCards.Queries.GetFlashCards;
using VocabularyBuilder.Data;

namespace VocabularyBuilder.API.Configurations
{
    public static class ApplicationSetup
    {
        public static IServiceCollection AddApplicationSetup(this IServiceCollection services)
        {
            var vocabularyBuilderMapperCfg = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddProfile<VocabularyBuilderMapper>();
                });
            var mapperVocabularyBuilder = vocabularyBuilderMapperCfg.CreateMapper();

            services.AddSingleton(mapperVocabularyBuilder);
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddMediatR(typeof(AddFlashCardCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(UpdateFlashCardCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(DeleteFlashCardCommand).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetFlashCardsQuery).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(GetCategoriesQuery).GetTypeInfo().Assembly);


            




            return services;
        }
    }
}
