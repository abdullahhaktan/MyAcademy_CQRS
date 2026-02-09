using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MyAcademyCQRS.Context;
using MyAcademyCQRS.CQRSPattern.Results.TestimonialResults;

namespace MyAcademyCQRS.CQRSPattern.Handlers.TestimonialHandlers
{
    public class GetTestimonialsQueryHandler(AppDbContext context, IMapper mapper)
    {
        public async Task<List<GetTestimonialsQueryResult>> Handle()
        {
            var testimonials = await context.Testimonials.ToListAsync();
            return mapper.Map<List<GetTestimonialsQueryResult>>(testimonials);
        }
    }
}
