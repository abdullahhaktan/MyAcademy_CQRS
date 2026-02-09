namespace MyAcademyCQRS.CQRSPattern.Commands.BlogCommands;

public record CreateBlogCommand(string Title, string Description, DateTime CreatedDate);