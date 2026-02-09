using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Results.StoryResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.StoryHandlers
{
    public class GetStoryByIdQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<GetStoryByIdQueryResult> Handle()
        {
            var story = await context.Stories.FindAsync(2);
            return mapper.Map<GetStoryByIdQueryResult>(story);
        }
    }
}
