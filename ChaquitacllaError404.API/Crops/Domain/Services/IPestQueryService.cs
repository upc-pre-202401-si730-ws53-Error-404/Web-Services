using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;

namespace ChaquitacllaError404.API.Crops.Domain.Services;

public interface IPestQueryService
{
    Task<Pest?> Handle(GetPestByIdQuery query);
    
    Task<IEnumerable<Pest>> Handle(GetAllPestsQuery query);
    Task<IEnumerable<Pest>> Handle(GetPestByCropIdQuery query);

}