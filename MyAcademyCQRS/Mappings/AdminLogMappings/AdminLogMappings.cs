using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Results.AdminLogResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings.AdminLogMappings
{
    public class AdminLogMappings : Profile
    {
        public AdminLogMappings()
        {
            CreateMap<AdminLog, GetAdminLogsQueryResult>();
        }
    }
}
