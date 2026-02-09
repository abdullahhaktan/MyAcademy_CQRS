using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.BlogQueries;
using MyAcademyCQRS.CQRSPattern.Results.BlogResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BlogHandlers
{
    public class GetBlogByIdQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery getBlogByIdQuery)
        {
            var blog = await context.Blogs.FindAsync(getBlogByIdQuery.Id);
            return mapper.Map<GetBlogByIdQueryResult>(blog);
        }
    }
}