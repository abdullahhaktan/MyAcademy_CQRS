using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.BlogCommands;

public record RemoveBlogCommand(int Id) : IRequest;