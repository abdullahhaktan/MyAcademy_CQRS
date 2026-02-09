using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.BlogQueries;
using MyAcademyCQRS.CQRSPattern.Results.BlogResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BlogHandlers
{
    public class GetBlogsQueryHandler(AppDbContext context, IMapper mapper) : IRequestHandler<GetBlogsQuery, List<GetBlogsQueryResult>>
    {
        public async Task<List<GetBlogsQueryResult>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
        {
            var blogs = await context.Blogs.AsNoTracking().ToListAsync();
            return mapper.Map<List<GetBlogsQueryResult>>(blogs);
        }
    }
}