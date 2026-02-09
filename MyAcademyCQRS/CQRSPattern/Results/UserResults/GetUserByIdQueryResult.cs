using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.CartResults;
using MyAcademyCQRS.CQRSPattern.Results.OrderResults;

namespace MyAcademyCQRS.CQRSPattern.Results.UserResults
{
    public class GetUserByIdQueryResult : IRequest
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ImageUrl { get; set; }
        public GetOrdersQueryResult getOrdersQueryResult { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public GetCartsQueryResult getCartsQueryResult { get; set; }
    }
}