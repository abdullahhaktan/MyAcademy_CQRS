using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.FeatureCommands;

public record RemoveFeatureCommand(int Id) : IRequest;