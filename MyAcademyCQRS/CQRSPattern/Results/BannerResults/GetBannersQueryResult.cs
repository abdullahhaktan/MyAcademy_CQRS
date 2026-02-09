namespace MyAcademyCQRS.CQRSPattern.Results.BannerResults;

public record GetBannersQueryResult(int Id,
                                    string Title,
                                    string Description,
                                    string ImageUrl);