using MediatR;

namespace MyAcademyCQRS.CQRSPattern.Commands.UserCommands;

public class RemoveUserCommand : IRequest
{
    public int Id { get; set; }

    public RemoveUserCommand(int id)
    {
        Id = id;
    }
}