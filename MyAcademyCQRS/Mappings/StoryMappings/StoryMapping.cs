using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.StoryCommands;
using MyAcademyCQRS.CQRSPattern.Results.StoryResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings.StoryMappings
{
    public class StoryMapping : Profile
    {
        public StoryMapping()
        {
            CreateMap<Story, GetStoriesQueryResult>();
            CreateMap<CreateStoryCommand, Story>().ReverseMap();
            CreateMap<Story, GetStoryByIdQueryResult>();
            CreateMap<UpdateStoryCommand, Story>();
        }
    }
}
