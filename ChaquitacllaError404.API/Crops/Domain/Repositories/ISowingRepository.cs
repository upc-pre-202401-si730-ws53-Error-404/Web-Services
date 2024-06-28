using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.Crops.Domain.Repositories;

public interface ISowingRepository : IBaseRepository<Sowing>
{
    Task<IEnumerable<Sowing>> FindByStatusAsync(bool status);
    Task UpdateAsync(Sowing sowing);
    Task<IEnumerable<Product>> FindProductsBySowing(int sowingId);

    Task<IEnumerable<Sowing>> FindAllAsync();
}