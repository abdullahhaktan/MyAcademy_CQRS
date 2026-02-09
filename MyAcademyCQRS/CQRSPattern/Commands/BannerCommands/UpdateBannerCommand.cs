namespace MyAcademyCQRS.CQRSPattern.Commands.BannerCommands;

public record UpdateBannerCommand(int Id,
                                  string Title,
                                  string Description,
                                  string ImageUrl);