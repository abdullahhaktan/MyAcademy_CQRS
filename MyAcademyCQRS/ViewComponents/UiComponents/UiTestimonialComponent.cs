using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.TestimonialHandlers;

namespace MyAcademyCQRS.ViewComponents.UiComponents
{
    public class UiTestimonialComponent(GetTestimonialsQueryHandler getTestimonialsQueryHandler) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var testimonials = await getTestimonialsQueryHandler.Handle();
            return View(testimonials);
        }
    }
}
