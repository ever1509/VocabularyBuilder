using Application.Common.Mappings;
using AutoMapper;
using Domain.Entities;

namespace Application.Categories.Queries.GetCategories
{
    public class CategoryDto:IMapFrom<CategoryDto>
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Category, CategoryDto>()
                .ForMember(d => d.Description, opt => opt.MapFrom(e => e.Description))
                .ForMember(d => d.Id, opt => opt.MapFrom(e => e.CategoryId));
        }
    }
}
