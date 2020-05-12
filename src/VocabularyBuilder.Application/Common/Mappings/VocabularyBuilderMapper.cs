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
                .ForMember(d => d.TypeCard, opt => opt.MapFrom(e => AddTypeCard(e)))
                .ForMember(d=>d.Meaning,opt=>opt.MapFrom(e=>AddDescription(e)))
                .ForMember(d=>d.MeaningId,opt=>opt.MapFrom(e=>e.MeaningId))
                .ForMember(d=>d.MainWord,opt=>opt.MapFrom(e=>e.MainWord))
                .ForMember(d=>d.Id,opt=>opt.MapFrom(e=>e.FlashCardId))
                .ForMember(d=>d.Example,opt=>opt.MapFrom(e=>e.Example));



        }

        private TypeCardStatus AddTypeCard(FlashCard flashCard)
        {
            if (flashCard == null)
                throw new Exception("It doesn't exist the flashcard");

            switch (flashCard.TypeCardId)
            {
                case 1:
                    return TypeCardStatus.Daily;
                case 2:
                    return TypeCardStatus.Weekly;
                case 3:
                    return TypeCardStatus.Monthly;
            }

            return 0;
        }

        private string AddDescription(FlashCard flashCard)
        {
            if (flashCard == null)
                return String.Empty;
            return flashCard.Meaning.Description;
        }
    }
}
