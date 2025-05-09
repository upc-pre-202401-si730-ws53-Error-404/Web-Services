using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Crops.Domain.Services;

namespace ChaquitacllaError404.API.Crops.Application.QueryServices;

public class CropQueryService(ICropRepository cropRepository)
    : ICropQueryService
{
    public async Task<Crop?> Handle(GetCropByIdQuery query)
    {
        return await cropRepository.FindByIdAsync(query.Id);
    }    
    
    public async Task<IEnumerable<Crop>> Handle(GetAllCropsQuery query)
    {
        return await cropRepository.FindAllAsync();
    }
}
