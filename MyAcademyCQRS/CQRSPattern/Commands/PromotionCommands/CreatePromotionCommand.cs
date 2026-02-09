namespace MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands;

public record CreatePromotionCommand(string Title, string ImageUrl, string Description, decimal Price);