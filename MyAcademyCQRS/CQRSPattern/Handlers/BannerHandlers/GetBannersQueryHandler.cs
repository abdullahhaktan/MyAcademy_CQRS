using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Results.BannerResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.BannerHandlers
{
    public class GetBannersQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<List<GetBannersQueryResult>> Handle()
        {
            var banners = await context.Banners.ToListAsync();
            return mapper.Map<List<GetBannersQueryResult>>(banners);
        }
    }
}
