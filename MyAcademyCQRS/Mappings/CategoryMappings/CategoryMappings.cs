using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands;
using MyAcademyCQRS.CQRSPattern.Results.CategoryResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings.CategoryMappings
{
    public class CategoryMappings : Profile
    {
        public CategoryMappings()
        {
            CreateMap<Category, GetCategoriesQueryResult>();
            CreateMap<CreateCategoryCommand, Category>();
            CreateMap<Category, GetCategoryByIdQueryResult>();
        }
    }
}
