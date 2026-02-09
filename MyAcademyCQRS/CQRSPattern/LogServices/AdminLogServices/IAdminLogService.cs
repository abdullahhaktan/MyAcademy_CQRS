namespace MyAcademyCQRS.CQRSPattern.LogServices.AdminLogServices
{
    public interface IAdminLogService
    {
        public Task WriteLog(string logType, string action, string description);
    }
}
