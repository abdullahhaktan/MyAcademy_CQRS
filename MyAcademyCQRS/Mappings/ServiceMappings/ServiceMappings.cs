using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.ServiceCommands;
using MyAcademyCQRS.CQRSPattern.Results.ServiceResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings.ServiceMappings
{
    public class ServiceMappings : Profile
    {
        public ServiceMappings()
        {
            CreateMap<Service, GetServicesQueryResult>();
            CreateMap<CreateServiceCommand, Service>().ReverseMap();
            CreateMap<Service, GetServiceByIdQueryResult>();
            CreateMap<UpdateServiceCommand, Service>();
        }
    }
}
