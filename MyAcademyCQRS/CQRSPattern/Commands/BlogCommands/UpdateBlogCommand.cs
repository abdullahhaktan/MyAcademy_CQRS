using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.BlogCommands;

public record UpdateBlogCommand(int Id, string Title, string Description, DateTime CreatedDate) : IRequest;