using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using VocabularyBuilder.Application.Categories.Queries.GetCategories;
using VocabularyBuilder.Application.Common.Enums;
using VocabularyBuilder.Application.FlashCards.Queries.GetFlashCards;
using VocabularyBuilder.Data.Migrations;
using VocabularyBuilder.Domain.Entities;

namespace VocabularyBuilder.Application.Common.Mappings
{
    public class VocabularyBuilderMapper:Profile
    {
        public VocabularyBuilderMapper()
        {
            CreateMap<Category, CategoryDto>()
                .ForMember(d => d.Description, opt => opt.MapFrom(e => e.Description))
                .ForMember(d => d.Id, opt => opt.MapFrom(e => e.CategoryId));


            CreateMap<FlashCard, FlashCardDto>()
                .ForMember(d => d.TypeCard, opt => opt.MapFrom(e =>(TypeCardStatus)e.TypeCardId))
                .ForMember(d=>d.Meaning,opt=>opt.MapFrom(e=>e.Meaning))
                .ForMember(d=>d.MainWord,opt=>opt.MapFrom(e=>e.MainWord))
                .ForMember(d=>d.Id,opt=>opt.MapFrom(e=>e.FlashCardId))
                .ForMember(d=>d.Example,opt=>opt.MapFrom(e=>e.Example));



        }
    }
}
