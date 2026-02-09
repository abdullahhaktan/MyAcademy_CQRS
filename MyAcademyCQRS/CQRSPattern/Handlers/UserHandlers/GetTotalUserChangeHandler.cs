using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;

namespace MyAcademyCQRS.CQRSPattern.Handlers.UserHandlers
{
    public class GetTotalUserChangeHandler(AppDbContext context)
    {
        public async Task<int> Handle()
        {
            var todayTotalUserCount = await context.Users.CountAsync();
            todayTotalUserCount = todayTotalUserCount <= 0 ? 1 : todayTotalUserCount;

            var tenDaysAgo = DateTime.UtcNow.AddDays(-10);

            var tenDaysAgoTotalUserCount = await context.Users.CountAsync(u => u.CreatedDate <= tenDaysAgo);
            tenDaysAgoTotalUserCount = tenDaysAgoTotalUserCount <= 0 ? 1 : tenDaysAgoTotalUserCount;

            var changePercentage = (todayTotalUserCount - tenDaysAgoTotalUserCount) * 100 / tenDaysAgoTotalUserCount;

            return changePercentage;
        }
    }
}
