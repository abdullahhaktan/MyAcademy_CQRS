
using MyAcademyCQRS.Context;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.LogServices.AdminLogServices
{
    public class AdminLogService(AppDbContext context) : IAdminLogService
    {
        public async Task WriteLog(string logType, string action, string description)
        {
            var newLog = new AdminLog
            {
                AdminUsername = "abdullahhktn",
                LogType = logType,
                Action = action,
                Description = description,
                IpAddress = "127.0.0.1",
            };

            await context.AddAsync(newLog);
            await context.SaveChangesAsync();
        }
    }
}
