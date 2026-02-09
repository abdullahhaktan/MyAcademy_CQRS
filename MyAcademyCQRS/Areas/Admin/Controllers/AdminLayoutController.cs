using Microsoft.AspNetCore.Mvc;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminLayoutController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View();
        }
    }
}
