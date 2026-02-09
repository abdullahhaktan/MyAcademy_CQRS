using AutoMapper;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Queries.TestimonialQueries;
using MyAcademyCQRS.CQRSPattern.Results.TestimonialResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.TestimonialHandlers
{
    public class GetTestimonialByIdQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<GetTestimonialByIdQueryResult> Handle(GetTestimonialByIdQuery getTestimonialByIdQuery)
        {
            var testimonial = await context.Testimonials.FindAsync(getTestimonialByIdQuery.Id);
            return mapper.Map<GetTestimonialByIdQueryResult>(testimonial);
        }
    }
}
