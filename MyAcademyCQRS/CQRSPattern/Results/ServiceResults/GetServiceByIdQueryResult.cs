namespace MyAcademyCQRS.CQRSPattern.Results.ServiceResults;

public record GetServiceByIdQueryResult(int Id, string Title, string Description, string IconClass);