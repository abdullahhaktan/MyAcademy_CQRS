using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.ServiceCommands;

public record UpdateServiceCommand(int Id,
                                  string Title,
                                  string Description,
                                  string IconClass) : IRequest;