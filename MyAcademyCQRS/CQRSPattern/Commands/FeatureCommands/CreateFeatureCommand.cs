using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.FeatureCommands;

public record CreateFeatureCommand(string Title, string Description) : IRequest;