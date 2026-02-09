using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Handlers.StoryHandlers;

namespace MyAcademyCQRS.ViewComponents.UiComponents
{
    public class UiOurStoryComponent(GetStoryByIdQueryHandler getStoryByIdQueryHandler) : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var story = await getStoryByIdQueryHandler.Handle();
            return View(story);
        }
    }
}
