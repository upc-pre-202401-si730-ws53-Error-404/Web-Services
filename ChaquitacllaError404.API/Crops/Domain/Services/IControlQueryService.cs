using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;

namespace ChaquitacllaError404.API.Crops.Domain.Services;

public interface IControlQueryService
{
    Task<Control> Handle(GetControlByIdQuery query);
    Task < List<Control>> Handle (GetAllControlsQuery query);
}