using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.TestimonialCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.TestimonialHandlers
{
    public class CreateTestimonialCommandHandler(AppDbContext context, IMapper mapper)
    {
        public async Task Handle(CreateTestimonialCommand createTestimonialCommand)
        {
            var testimonial = mapper.Map<Testimonial>(createTestimonialCommand);
            context.Update(testimonial);
            await context.SaveChangesAsync();
        }
    }
}
