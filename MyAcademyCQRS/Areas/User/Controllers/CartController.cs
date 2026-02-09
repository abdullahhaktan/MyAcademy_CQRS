using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.OrderCommands;
using MyAcademyCQRS.CQRSPattern.Commands.OrderItemCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.CartHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderHandlers;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderItemHandlers;
using MyAcademyCQRS.CQRSPattern.MailServices;
using MyAcademyCQRS.CQRSPattern.Queries.CartQueries;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Areas.User.Controllers
{
    [Area("User")]
    public class CartController(CreateOrderCommandHandler createOrderCommandHandler, GetOrderItemsCountQueryHandler getOrderItemsCountQueryHandler,
      GetOrderByUserIdQueryHandler getOrderByUserIdQueryHandler, GetCartByUserQueryHandler getCartByUserQueryHandler, UserManager<AppUser> userManager, IMediator mediator, IMapper mapper, IMailSender mailSender) : Controller
    {
        private async Task GetOrderItemCountAsync()
        {
            if (User.Identity.Name != null)
            {
                var user = await userManager.FindByNameAsync(User.Identity.Name);
                var orderItemsCount = await getOrderItemsCountQueryHandler.Handle(user.Id);
                ViewBag.orderItemsCount = orderItemsCount;
            }
        }

        public async Task<IActionResult> Index()
        {
            await GetOrderItemCountAsync();
            var user = await userManager.FindByNameAsync(User.Identity.Name);
            var cart = await mediator.Send(new GetCartByUserQuery(user.Id));
            if (cart.OrderItems == null)
            {
                cart = null;
                return View(cart);
            }

            return View(cart);
        }

        public async Task<IActionResult> RemoveOrderItem(int id)
        {
            await mediator.Send(new RemoveOrderItemCommand(id));
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ApproveOrder(int id)
        {
            var user = await userManager.FindByNameAsync(User.Identity.Name);

            var cart = await mediator.Send(new GetCartByIdQuery(id));

            decimal totalPrice = cart.OrderItems.Sum(x => x.UnitPrice);

            CreateOrderCommand command = new CreateOrderCommand
            {
                UserId = cart.AppUserId,
                Status = "pending",
                TotalPrice = totalPrice
            };

            // 🔥 TEK ÇAĞRI
            await createOrderCommandHandler.Handle(command);

            var mailBody = $@"
                Merhaba {user.FirstName} {user.LastName},

                Siparişiniz başarıyla alınmıştır 🎉

                🧾 Sipariş Özeti
                -------------------------
                • Toplam Tutar : {totalPrice:C}
                • Sipariş Durumu : Beklemede
                • Sipariş Tarihi : {DateTime.Now:dd.MM.yyyy HH:mm}

                Siparişiniz en kısa sürede işleme alınacaktır.
                Herhangi bir sorunuz olursa bizimle iletişime geçebilirsiniz.

                İyi günler dileriz,
                MyAcademy Ekibi
                ";

            await mailSender.SendAsync(
                user.Email,
                "📦 Siparişiniz Alındı",
                mailBody
            );

            TempData["message"] = "mail sent";

            return RedirectToAction("Index");
        }
    }
}
