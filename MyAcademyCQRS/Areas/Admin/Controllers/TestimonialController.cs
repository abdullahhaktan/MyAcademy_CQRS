using Microsoft.AspNetCore.Mvc;
using MyAcademyCQRS.CQRSPattern.Commands.TestimonialCommands;
using MyAcademyCQRS.CQRSPattern.Handlers.TestimonialHandlers;
using MyAcademyCQRS.CQRSPattern.Queries.TestimonialQueries;
using MyAcademyCQRS.CQRSPattern.StorageServices;

namespace MyAcademyCQRS.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly GetTestimonialsQueryHandler _getTestimonialsQueryHandler;
        private readonly GetTestimonialByIdQueryHandler _getTestimonialByIdQueryHandler;
        private readonly CreateTestimonialCommandHandler _createTestimonialCommandHandler;
        private readonly UpdateTestimonialCommandHandler _updateTestimonialCommandHandler;
        private readonly RemoveTestimonialCommandHandler _removeTestimonialCommandHandler;
        private readonly IFileStorageService _fileStorageService;

        public TestimonialController(
            GetTestimonialsQueryHandler getTestimonialsQueryHandler,
            GetTestimonialByIdQueryHandler getTestimonialByIdQueryHandler,
            CreateTestimonialCommandHandler createTestimonialCommandHandler,
            UpdateTestimonialCommandHandler updateTestimonialCommandHandler,
            RemoveTestimonialCommandHandler removeTestimonialCommandHandler,
            IFileStorageService fileStorageService)
        {
            _getTestimonialsQueryHandler = getTestimonialsQueryHandler;
            _getTestimonialByIdQueryHandler = getTestimonialByIdQueryHandler;
            _createTestimonialCommandHandler = createTestimonialCommandHandler;
            _updateTestimonialCommandHandler = updateTestimonialCommandHandler;
            _removeTestimonialCommandHandler = removeTestimonialCommandHandler;
            _fileStorageService = fileStorageService;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _getTestimonialsQueryHandler.Handle();
            return View(values);
        }

        public async Task<IActionResult> CreateTestimonial()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTestimonial(CreateTestimonialCommand command, IFormFile ImageFile)
        {
            if (ImageFile != null)
                command = command with { ImageUrl = await _fileStorageService.UploadFileAsync(ImageFile, "testimonials") };

            await _createTestimonialCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> UpdateTestimonial(int id)
        {
            var value = await _getTestimonialByIdQueryHandler.Handle(new GetTestimonialByIdQuery(id));
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateTestimonial(UpdateTestimonialCommand command, IFormFile ImageFile)
        {
            if (ImageFile != null)
                command = command with { ImageUrl = await _fileStorageService.UploadFileAsync(ImageFile, "testimonials") };

            await _updateTestimonialCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteTestimonial(int id)
        {
            await _removeTestimonialCommandHandler.Handle(new RemoveTestimonialCommand(id));
            return RedirectToAction("Index");
        }
    }
}
