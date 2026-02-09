using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.BannerCommands;
using MyAcademyCQRS.CQRSPattern.Results.BannerResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings.BannerMappings
{
    public class BannerMappings : Profile
    {
        public BannerMappings()
        {
            CreateMap<Banner, GetBannersQueryResult>();
            CreateMap<CreateBannerCommand, Banner>();
            CreateMap<Banner, GetBannerByIdQueryResult>();
        }
    }
}
