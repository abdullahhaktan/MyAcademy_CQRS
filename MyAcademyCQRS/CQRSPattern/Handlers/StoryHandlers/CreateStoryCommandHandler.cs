using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.StoryCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.StoryHandlers
{
    public class CreateStoryCommandHandler(AppDbContext context, IMapper mapper)
    {
        public async Task Handle(CreateStoryCommand createStoryCommand)
        {
            var story = mapper.Map<Story>(createStoryCommand);
            await context.AddAsync(story);
            await context.SaveChangesAsync();
        }
    }
}
