using Microsoft.Build.Tasks.Deployment.Bootstrapper;

namespace MyAcademyCQRS.CQRSPattern.Commands.CategoryCommands;

public class CreateCategoryCommand
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Icon { get; set; }
    public IList<Product> Products { get; set; }
}