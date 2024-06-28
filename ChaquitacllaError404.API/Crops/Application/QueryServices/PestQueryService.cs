using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Crops.Domain.Services;

namespace ChaquitacllaError404.API.Crops.Application.QueryServices;

public class PestQueryService(IPestRepository pestRepository)
    : IPestQueryService
{
    public async Task<Pest?> Handle(GetPestByIdQuery query)
    {
        return await pestRepository.FindByIdAsync(query.Id);
    }
    
    public Task<IEnumerable<Pest>> Handle(GetAllPestsQuery query)
    {
        return pestRepository.FindAllAsync();
    }
}
