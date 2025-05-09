using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;

namespace ChaquitacllaError404.API.Crops.Domain.Services;

public interface ICareQueryService
{
    Task<Care?> Handle(GetCareByIdQuery query);
    
    Task<IEnumerable<Care>> Handle(GetCareByCropIdQuery query);
}