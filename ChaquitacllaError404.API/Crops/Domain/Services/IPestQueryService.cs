using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;

namespace ChaquitacllaError404.API.Crops.Domain.Services;

public interface IPestQueryService
{
    Task<Pest?> Handle(GetPestByIdQuery query);
}