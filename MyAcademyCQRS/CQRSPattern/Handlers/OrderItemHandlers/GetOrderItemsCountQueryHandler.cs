using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderItemHandlers
{
    public class GetOrderItemsCountQueryHandler(AppDbContext context, UserManager<AppUser> userManager)
    {
        public async Task<int> Handle(int UserId)
        {
            var orderItemsCount = await context.OrderItems.Where(o => o.Cart.AppUserId == UserId).CountAsync();
            return orderItemsCount;
        }
    }
}
