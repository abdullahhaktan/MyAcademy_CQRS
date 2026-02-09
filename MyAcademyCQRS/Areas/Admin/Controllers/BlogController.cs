using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.BlogCommands;
using MyAcademyCQRS.CQRSPattern.Queries.BlogQueries;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController(IMediator mediator) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var Blogs = await mediator.Send(new GetBlogsQuery());
            return View(Blogs);
        }

        public async Task<IActionResult> CreateBlog()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBlog(CreateBlogCommand command)
        {
            await mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateBlog(int id)
        {
            var Blog = await mediator.Send(new GetBlogByIdQuery(id));
            return View(Blog);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBlog(UpdateBlogCommand command)
        {
            await mediator.Send(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteBlog(int id)
        {
            await mediator.Send(new RemoveBlogCommand(id));
            return RedirectToAction("Index");
        }
    }
}
