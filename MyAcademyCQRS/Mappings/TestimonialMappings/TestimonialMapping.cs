using AutoMapper;
using MyAcademyCQRS.CQRSPattern.Commands.TestimonialCommands;
using MyAcademyCQRS.CQRSPattern.Results.TestimonialResults;
using MyAcademyCQRS.Entities;

namespace MyAcademyCQRS.Mappings.TestimonialMappings
{
    public class TestimonialMapping : Profile
    {
        public TestimonialMapping()
        {
            CreateMap<Testimonial, GetTestimonialsQueryResult>();
            CreateMap<CreateTestimonialCommand, Testimonial>().ReverseMap();
            CreateMap<Testimonial, GetTestimonialByIdQueryResult>();
            CreateMap<UpdateTestimonialCommand, Testimonial>();
        }
    }
}
