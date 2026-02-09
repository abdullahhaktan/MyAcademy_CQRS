namespace MyAcademyCQRS.Entities
{
    public class Order
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public AppUser User { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public string Status { get; set; }
        public decimal TotalPrice { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
