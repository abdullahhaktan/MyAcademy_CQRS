using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Commands.OrderCommands;
public class CreateOrderCommand
{
    public AppUser User { get; set; }
    public int UserId { get; set; }

    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    public string Status { get; set; }
    public decimal TotalPrice { get; set; }
    public ICollection<OrderItem> OrderItems { get; set; }
}