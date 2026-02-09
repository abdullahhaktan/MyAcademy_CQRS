using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern;
using MyAcademyCQRS.CQRSPattern.Commands.CartCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.CartHandlers;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Controllers
{
    [AllowAnonymous]
    public class RegisterController(UserManager<AppUser> userManager, CreateCartCommandHandler createCartCommandHandler, IMediator mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(RegisterDto registerDto)
        {
            //if(!ModelState.IsValid)
            //{
            //    return View(registerDto);
            //}


            var user = new AppUser
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                UserName = registerDto.UserName,
                ImageUrl = registerDto.ImageUrl,
            };

            var result = await userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerDto);
            }

            CreateCartCommand createCartCommand = new CreateCartCommand(user.Id, false, DateTime.Now);

            await mediator.Send(createCartCommand);

            return RedirectToAction("CustomerLogin", "Login");
        }
    }
}
