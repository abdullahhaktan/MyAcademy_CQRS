using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.ServiceCommands;

public record CreateServiceCommand(string Title,
                                   string Description,
                                   string IconClass) : IRequest;