using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers
{
    public class GetTotalActiveOrderCountHandler(AppDbContext context, IMapper mapper, UserManager<AppUser> userManager)
    {
        public async Task<int> Handle(int Id)
        {
            var orderCount = await context.Orders.Where(o => o.Status.ToLower() != "completed" && o.UserId == Id).CountAsync();
            return orderCount;
        }
    }
}
