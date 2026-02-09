using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Queries.BlogQueries;

namespace MyAcademyCQRS.ViewComponents.UiComponents
{
    public class UiBlogComponent(IMediator mediator) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var blogs = await mediator.Send(new GetBlogsQuery());
            return View(blogs);
        }
    }
}
