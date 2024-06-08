using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;

namespace ChaquitacllaError404.API.Crops.Domain.Services;

public interface ISowingQueryService
{
    Task<Sowing?> Handle(GetSowingByIdQuery query);
    Task<IEnumerable<Sowing>> Handle(GetSowingByStatusQuery query);
}