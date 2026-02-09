namespace MyAcademyCQRS.CQRSPattern.Commands.PromotionCommands;

public record UpdatePromotionCommand(int Id, string Title, string Description, string ImageUrl, decimal Price);