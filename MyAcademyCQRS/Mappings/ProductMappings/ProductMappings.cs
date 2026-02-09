using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;
using MyAcademyCQRS.CQRSPattern.Results.ProductResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings.ProductMappings
{
    public class ProductMappings : Profile
    {
        public ProductMappings()
        {
            CreateMap<Product, GetProductsQueryResult>();
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<Product, GetProductByIdQueryResult>();
            CreateMap<UpdateProductCommand, Product>().ForAllMembers(opt => opt.Condition((src, dst, srcMember) => srcMember != null));
        }
    }
}
