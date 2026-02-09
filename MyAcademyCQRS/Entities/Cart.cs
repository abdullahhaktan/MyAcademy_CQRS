namespace MyAcademyCQRS.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        public AppUser AppUser { get; set; }
        public int AppUserId { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public bool IsDeleted { get; set; } = false;

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
