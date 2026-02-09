using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.CartCommands;
using MyAcademyCQRS.CQRSPattern.Results.CartResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings.CartMappings
{
    public class CartMappings : Profile
    {
        public CartMappings()
        {
            CreateMap<Cart, GetCartsQueryResult>();
            CreateMap<CreateCartCommand, Cart>();
            CreateMap<Cart, GetCartByIdQueryResult>();
            CreateMap<Cart, GetCartByUserQueryResult>();
        }
    }
}
