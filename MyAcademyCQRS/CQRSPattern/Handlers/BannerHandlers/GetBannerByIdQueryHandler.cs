using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.BannerQueries;
using MyAcademyCQRS.CQRSPattern.Results.BannerResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var banner = await context.Banners.FindAsync(query.Id);
            return mapper.Map<GetBannerByIdQueryResult>(banner);
        }
    }
}
