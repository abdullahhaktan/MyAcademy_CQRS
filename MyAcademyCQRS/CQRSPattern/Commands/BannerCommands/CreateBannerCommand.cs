namespace MyAcademyCQRS.CQRSPattern.Commands.BannerCommands;

public record CreateBannerCommand(string Title,
                                  string Description,
                                  string ImageUrl);