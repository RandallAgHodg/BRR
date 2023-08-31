using BRR.Application.Abstractions.Messaging;
using BRR.Contracts.Responses.Houses;

namespace BRR.Application.Houses.Queries.GetTop5Houses;

public sealed record GetTop5HousesByDiscountQuery : IQuery<IEnumerable<HouseResponse>>;
