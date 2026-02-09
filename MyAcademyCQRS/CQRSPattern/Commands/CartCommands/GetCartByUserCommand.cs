using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.CartCommands;

public record GetCartByUserCommand(int Id) : IRequest;