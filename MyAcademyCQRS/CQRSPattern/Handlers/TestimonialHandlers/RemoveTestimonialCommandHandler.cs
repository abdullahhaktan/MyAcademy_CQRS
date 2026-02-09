using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.TestimonialCommands;

namespace MyAcademyCQRS.CQRSPattern.Handlers.TestimonialHandlers
{
    public class RemoveTestimonialCommandHandler(AppDbContext context)
    {
        public async Task Handle(RemoveTestimonialCommand removeTestimonialCommand)
        {
            var testimonial = await context.Testimonials.FindAsync(removeTestimonialCommand.Id);
            context.Testimonials.Remove(testimonial);
            await context.SaveChangesAsync();
        }
    }
}
