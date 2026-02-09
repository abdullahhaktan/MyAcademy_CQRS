namespace MyAcademyCQRS.CQRSPattern.Commands.ProductCommands;

public record UpdateProductCommand(int Id,
                                    string Title,
                                    string Description,
                                    string Description1,
                                    decimal Price,
                                    string ImageUrl,
                                    string ImageUrl1,
                                    string ImageUrl2,
                                    string ImageUrl3,
                                    int CategoryId);