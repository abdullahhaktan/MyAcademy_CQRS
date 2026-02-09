
using MyAcademyCQRS.Context;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.LogServices.CustomerLogServices
{
    public class CustomerLogService(AppDbContext context) : ICustomerLogService
    {
        public async Task WriteLog(string email, string action, string ipAdress, string logType, string description)
        {
            var newLog = new CustomerLog
            {
                Email = email,
                LogType = logType,
                Action = action,
                Description = description,
                IpAddress = "127.0.0.1",
                CreatedDate = DateTime.Now,
            };

            await context.CustomerLogs.AddAsync(newLog);
            await context.SaveChangesAsync();
        }
    }
}
