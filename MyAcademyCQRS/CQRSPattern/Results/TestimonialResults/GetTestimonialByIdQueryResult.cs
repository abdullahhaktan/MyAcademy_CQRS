namespace MyAcademyCQRS.CQRSPattern.Results.TestimonialResults;
public record GetTestimonialByIdQueryResult(int Id, string FullName, string ImageUrl, string Title, string Comment);