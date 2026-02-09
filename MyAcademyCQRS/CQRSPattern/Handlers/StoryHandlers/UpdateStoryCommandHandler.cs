using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.StoryCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.StoryHandlers
{
    public class UpdateStoryCommandHandler(AppDbContext context, IMapper mapper)
    {
        public async Task Handle(UpdateStoryCommand command)
        {
            var story = mapper.Map<Story>(command);
            context.Update(story);
            await context.SaveChangesAsync();
        }
    }
}
