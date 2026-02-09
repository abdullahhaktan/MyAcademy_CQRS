using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.OrderCommands;
using MyAcademyCQRS.CQRSPattern.Results.OrderResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings.OrderMappings
{
    public class OrderMappings : Profile
    {
        public OrderMappings()
        {
            CreateMap<Order, GetOrdersQueryResult>();
            CreateMap<Order, GetOrderByIdQueryResult>();
            CreateMap<Order, GetOrdersByUserIdQueryResult>();
            CreateMap<UpdateOrderCommand, Order>();
            CreateMap<CreateOrderCommand, Order>();
        }
    }
}
