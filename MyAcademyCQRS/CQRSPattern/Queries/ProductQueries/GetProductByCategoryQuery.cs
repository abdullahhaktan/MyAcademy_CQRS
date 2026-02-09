namespace MyAcademyCQRS.CQRSPattern.Queries.ProductQueries
{
    public class GetProductByCategoryQuery
    {
        public int Id { get; set; }

        public GetProductByCategoryQuery(int id)
        {
            Id = id;
        }
    }
}
