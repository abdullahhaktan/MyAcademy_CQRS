using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.ServiceCommands;

public record RemoveServiceCommand(int Id) : IRequest;