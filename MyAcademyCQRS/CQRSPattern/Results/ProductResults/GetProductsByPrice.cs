using MyAcademyCQRS.CQRSPattern.Results.CategoryResults;

namespace MyAcademyCQRS.CQRSPattern.Results.ProductResults
{
    public class GetProductsByPrice
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Description1 { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }

        public int CategoryId { get; set; }
        public GetCategoriesQueryResult Category { get; set; }
    }
}
