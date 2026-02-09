using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Results.CategoryResults;

public class GetCategoryByIdQueryResult
{
    public readonly int Id;
    public readonly string Name;
    public readonly string Description;
    public readonly string Icon;
    public readonly IList<Product> Products;

    public GetCategoryByIdQueryResult(int Id, string Name, string Description, string Icon, IList<Product> Products)
    {
        this.Id = Id;
        this.Name = Name;
        this.Description = Description;
        this.Icon = Icon;
        this.Products = Products;
    }
}