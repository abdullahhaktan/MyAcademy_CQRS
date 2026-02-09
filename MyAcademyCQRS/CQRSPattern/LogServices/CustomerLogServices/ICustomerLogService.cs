namespace MyAcademyCQRS.CQRSPattern.LogServices.CustomerLogServices
{
    public interface ICustomerLogService
    {
        public Task WriteLog(string email, string action, string ipAdress, string logType, string description);
    }
}
