namespace MyAcademyCQRS.CQRSPattern.Commands.TestimonialCommands;

public record CreateTestimonialCommand(string FullName, string ImageUrl, string Title, string Comment);