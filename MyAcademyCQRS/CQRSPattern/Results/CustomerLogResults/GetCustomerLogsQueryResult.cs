namespace MyAcademyCQRS.CQRSPattern.Results.CustomerLogResults;

public record GetCustomerLogsQueryResult(int Id, string Email, string Action, string IpAddress, string LogType, string Description, DateTime CreatedDate);