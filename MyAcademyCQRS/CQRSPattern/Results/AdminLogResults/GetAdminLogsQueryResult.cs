namespace MyAcademyCQRS.CQRSPattern.Results.AdminLogResults;

public record GetAdminLogsQueryResult(int Id, string AdminUsername, string Action, string IpAddress, string LogType, string Description, DateTime CreatedDate);