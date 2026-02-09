using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Results.OrderResults
{
    public class GetOrdersQueryResult
    {
        public int Id { get; set; }

        public AppUser User { get; set; }
        public int UserId { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}