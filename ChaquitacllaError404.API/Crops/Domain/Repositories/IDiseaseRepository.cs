using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.Crops.Domain.Repositories;

public interface IDiseaseRepository : IBaseRepository<Disease>
{
    Task<IEnumerable<Disease>> FindAllAsync();
    
    Task<IEnumerable<Disease>> GetDiseasesByCropId(int cropId);
}