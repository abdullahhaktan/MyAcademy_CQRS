using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Results.StoryResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.StoryHandlers
{
    public class GetStoriesQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<List<GetStoriesQueryResult>> Handle()
        {
            var stories = await context.Stories.ToListAsync();
            return mapper.Map<List<GetStoriesQueryResult>>(stories);
        }
    }
}
