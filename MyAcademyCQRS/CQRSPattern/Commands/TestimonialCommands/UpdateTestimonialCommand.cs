namespace MyAcademyCQRS.CQRSPattern.Commands.TestimonialCommands;

public record UpdateTestimonialCommand(int Id, string FullName, string ImageUrl, string Title, string Comment);