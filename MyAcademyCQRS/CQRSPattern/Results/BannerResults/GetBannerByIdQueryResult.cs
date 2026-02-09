namespace MyAcademyCQRS.CQRSPattern.Results.BannerResults;

public record GetBannerByIdQueryResult(int Id, string Title, string Description, string ImageUrl);