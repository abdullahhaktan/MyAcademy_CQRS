using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Commands.TestimonialCommands;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.CQRSPattern.Handlers.TestimonialHandlers
{
    public class UpdateTestimonialCommandHandler(AppDbContext context, IMapper mapper)
    {
        public async Task Handle(UpdateTestimonialCommand updateTestimonialCommand)
        {
            var testimonial = mapper.Map<Testimonial>(updateTestimonialCommand);
            context.Testimonials.Update(testimonial);
            await context.SaveChangesAsync();
        }
    }
}
