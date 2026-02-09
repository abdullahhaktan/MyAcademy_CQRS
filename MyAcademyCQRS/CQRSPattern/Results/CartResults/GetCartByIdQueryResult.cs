using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Results.CartResults;

public record GetCartByIdQueryResult(int Id, int AppUserId, AppUser AppUser, ICollection<OrderItem> OrderItems, DateTime CreatedDate, bool IsDeleted);