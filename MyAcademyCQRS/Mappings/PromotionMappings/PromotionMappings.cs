using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands;
using MyAcademyCQRS.CQRSPattern.Results.PromotionResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings.PromotionMappings
{
    public class PromotionMappings : Profile
    {
        public PromotionMappings()
        {
            CreateMap<Promotion, GetPromotionsQueryResult>();
            CreateMap<CreatePromotionCommand, Promotion>().ReverseMap();
            CreateMap<Promotion, GetPromotionByIdQueryResult>();
            CreateMap<UpdatePromotionCommand, Promotion>();
        }
    }
}
