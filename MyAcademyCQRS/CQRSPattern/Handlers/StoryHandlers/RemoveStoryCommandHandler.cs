using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.StoryCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.StoryHandlers
{
    public class RemoveStoryCommandHandler(AppDbContext context)
    {
        public async Task Handle(RemoveStoryCommand removeStoryCommand)
        {
            var story = await context.Stories.FindAsync(removeStoryCommand.Id);
            context.Stories.Remove(story);
            await context.SaveChangesAsync();
        }
    }
}
