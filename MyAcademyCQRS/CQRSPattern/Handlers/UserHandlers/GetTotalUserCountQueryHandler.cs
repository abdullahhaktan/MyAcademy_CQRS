using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;

namespace MyAcademyCQRS.CQRSPattern.Handlers.UserHandlers
{
    public class GetTotalUserCountQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<int> Handle()
        {
            var totalUserCount = await context.Users.CountAsync();
            return totalUserCount;
        }
    }
}
