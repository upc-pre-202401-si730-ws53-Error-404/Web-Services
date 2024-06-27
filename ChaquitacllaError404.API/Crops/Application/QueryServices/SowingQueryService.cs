using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Crops.Domain.Services;

namespace ChaquitacllaError404.API.Crops.Application.QueryServices;

public class SowingQueryService(ISowingRepository sowingRepository)
: ISowingQueryService
{
    public async Task<Sowing?> Handle(GetSowingByIdQuery query)
    {
        return await sowingRepository.FindByIdAsync(query.Id);
    }
    public async Task<IEnumerable<Sowing>> Handle(GetSowingByStatusQuery query)
    {
        return await sowingRepository.FindByStatusAsync(query.Status);
    }
    
    public Task<IEnumerable<Sowing>> Handle(GetAllSowingsQuery query)
    {
        return sowingRepository.FindAllAsync();
    }
}