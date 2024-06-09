using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;

namespace ChaquitacllaError404.API.Crops.Domain.Services;

public interface IControlQueryService
{
    Task<IEnumerable<Controls>> Handle(GetAllControlsQuery query);
    Task<Controls?> Handle(GetControlByIdQuery query);
}