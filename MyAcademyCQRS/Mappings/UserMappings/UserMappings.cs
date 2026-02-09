using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Results.UserResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings.UserMappings
{
    public class UserMappings : Profile
    {
        public UserMappings()
        {
            CreateMap<AppUser, GetUsersQueryResult>();
        }
    }
}
