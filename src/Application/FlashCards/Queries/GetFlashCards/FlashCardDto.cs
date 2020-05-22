using System;
using System.Collections.Generic;
using System.Text;
using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;

namespace Application.FlashCards.Queries.GetFlashCards
{
    public class FlashCardDto : IMapFrom<FlashCardDto>
    {
        public int Id { get; set; }
        public string MainWord { get; set; }
        public string Example { get; set; }
        public int CategoryId { get; set; }
        public string Meaning { get; set; }
        public TypeCardStatus TypeCard { get; set; }
        public byte[] Picture { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<FlashCard, FlashCardDto>()
                .ForMember(d => d.TypeCard, opt => opt.MapFrom(e => (TypeCardStatus)e.TypeCardId))
                .ForMember(d => d.Meaning, opt => opt.MapFrom(e => e.Meaning))
                .ForMember(d => d.MainWord, opt => opt.MapFrom(e => e.MainWord))
                .ForMember(d => d.Id, opt => opt.MapFrom(e => e.FlashCardId))
                .ForMember(d => d.Example, opt => opt.MapFrom(e => e.Example))
                .ForMember(d => d.Picture, opt => opt.MapFrom(e => e.FlashCardPicture));
        }
    }
}
