using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.BlogCommands;
using MyAcademyCQRS.CQRSPattern.Results.BlogResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings.BlogMappings
{
    public class BlogMappings : Profile
    {
        public BlogMappings()
        {
            CreateMap<Blog, GetBlogsQueryResult>();
            CreateMap<CreateBlogCommand, Blog>();
            CreateMap<UpdateBlogCommand, Blog>();
        }
    }
}
