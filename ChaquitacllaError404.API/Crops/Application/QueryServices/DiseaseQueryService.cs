using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Crops.Domain.Services;

namespace ChaquitacllaError404.API.Crops.Application.QueryServices;

public class DiseaseQueryService(IDiseaseRepository diseaseRepository)
    : IDiseaseQueryService
{
    public async Task<Disease?> Handle(GetDiseaseByIdQuery query)
    {
        return await diseaseRepository.FindByIdAsync(query.Id);
    }
    
    public Task<IEnumerable<Disease>> Handle(GetAllDiseasesQuery query)
    {
        return diseaseRepository.FindAllAsync();
    }
}
