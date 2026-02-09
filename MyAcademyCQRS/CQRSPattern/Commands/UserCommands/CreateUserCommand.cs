using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.CartResults;
using MyAcademyCQRS.CQRSPattern.Results.OrderResults;

namespace MyAcademyCQRS.CQRSPattern.Commands.UserCommands

{
    public class CreateUserCommand : IRequest
    {
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