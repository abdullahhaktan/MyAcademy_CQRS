using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.StoryCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.StoryHandlers;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StoryController : Controller
    {
        private readonly GetStoryByIdQueryHandler _getStoryByIdQueryHandler;
        private readonly UpdateStoryCommandHandler _updateStoryCommandHandler;

        public StoryController(GetStoryByIdQueryHandler getStoryByIdQueryHandler, UpdateStoryCommandHandler updateStoryCommandHandler)
        {
            _getStoryByIdQueryHandler = getStoryByIdQueryHandler;
            _updateStoryCommandHandler = updateStoryCommandHandler;
        }

        public async Task<IActionResult> Index()
        {
            var story = await _getStoryByIdQueryHandler.Handle();
            return View(story);
        }

        [HttpPost]
        public async Task<IActionResult> Index(UpdateStoryCommand command)
        {
            await _updateStoryCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }
    }
}
