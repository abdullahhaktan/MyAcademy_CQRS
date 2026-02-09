using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.CartCommands;

public record RemoveCartCommand(int Id) : IRequest;