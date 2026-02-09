namespace MyAcademyCQRS.CQRSPattern.Results.BlogResults;
public record GetBlogsQueryResult(int Id, string Title, string Description, DateTime CreatedDate);