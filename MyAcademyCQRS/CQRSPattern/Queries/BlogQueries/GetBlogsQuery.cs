using MediatR;
using MyAcademyCQRS.CQRSPattern.Results.BlogResults;

namespace MyAcademyCQRS.CQRSPattern.Queries.BlogQueries;

public record GetBlogsQuery : IRequest<List<GetBlogsQueryResult>>;