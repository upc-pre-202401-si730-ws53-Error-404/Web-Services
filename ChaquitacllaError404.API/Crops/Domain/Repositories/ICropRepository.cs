using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.Crops.Domain.Repositories;

public interface ICropRepository: IBaseRepository<Crop>
{
    Task UpdateAsync(Crop crop);
}