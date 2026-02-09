namespace MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands;

public class RemoveCategoryCommand
{
    public int Id { get; set; }
    public RemoveCategoryCommand(int ıd)
    {
        Id = ıd;
    }
}