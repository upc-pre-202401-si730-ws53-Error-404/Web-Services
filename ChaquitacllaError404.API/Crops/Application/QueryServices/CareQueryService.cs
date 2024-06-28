using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Crops.Domain.Services;

namespace ChaquitacllaError404.API.Crops.Application.QueryServices;

public class CareQueryService(ICareRepository careRepository)
    : ICareQueryService
{
    public async Task<Care?> Handle(GetCareByIdQuery query)
    {
        return await careRepository.FindByIdAsync(query.Id);
    }
    
    public Task<IEnumerable<Care>> Handle(GetCareByCropIdQuery query)
    {
        return careRepository.GetCaresByCropIdQuery(query.CropId);
    }
}

