using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.OrderItemCommands;
using MyAcademyCQRS.CQRSPattern.Results.OrderItemResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings.OrderItemMappings
{
    public class OrderItemMappings : Profile
    {
        public OrderItemMappings()
        {
            CreateMap<OrderItem, GetOrderItemsQueryResult>();
            CreateMap<OrderItem, GetOrderItemByIdQueryResult>();
            CreateMap<UpdateOrderItemCommand, OrderItem>();
            CreateMap<GetOrderItemsQueryResult, UpdateOrderItemCommand>();
            CreateMap<CreateOrderItemCommand, OrderItem>();
        }
    }
}
