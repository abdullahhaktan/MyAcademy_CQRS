using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Results.CustomerLogResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings.CustomerLogMappings
{
    public class CustomerLogMappings : Profile
    {
        public CustomerLogMappings()
        {
            CreateMap<CustomerLog, GetCustomerLogsQueryResult>();
        }
    }
}
