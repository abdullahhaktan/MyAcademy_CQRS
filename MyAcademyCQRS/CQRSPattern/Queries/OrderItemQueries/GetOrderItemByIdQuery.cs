using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.OrderItemResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.OrderItemQueries;

public record GetOrderItemByIdQuery(int Id) : IRequest<GetOrderItemByIdQueryResult>;