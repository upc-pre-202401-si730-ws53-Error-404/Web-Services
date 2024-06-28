using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.Crops.Domain.Repositories;

public interface ICareRepository :IBaseRepository<Care>
{
    Task<IEnumerable<Care>> GetCaresByCropIdQuery(int cropId);

}