using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.ContactCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.OrderItemHandlers;
using MyAcademyCQRS.CQRSPattern.LogServices.CustomerLogServices;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Controllers
{
    [AllowAnonymous]
    public class ContactController(IMediator mediator, ICustomerLogService customerLogService, GetOrderItemsCountQueryHandler getOrderItemsCountQueryHandler, UserManager<AppUser> userManager) : Controller
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

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateContactCommand createContactCommand)
        {
            await mediator.Send(createContactCommand);

            await customerLogService.WriteLog(
                email: createContactCommand.Email,
                action: "Create Contact",
                ipAdress: "127.0.0.1",
                logType: "Information",
                description: $"'{createContactCommand.FullName}' adlı kullanıcı iletişim formu gönderdi. Konu: {createContactCommand.Subject}"

            );
            return RedirectToAction("Index");
        }
    }
}
