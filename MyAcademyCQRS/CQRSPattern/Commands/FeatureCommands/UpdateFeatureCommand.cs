using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.FeatureCommands;

public record UpdateFeatureCommand(int Id, string Title, string Description) : IRequest;