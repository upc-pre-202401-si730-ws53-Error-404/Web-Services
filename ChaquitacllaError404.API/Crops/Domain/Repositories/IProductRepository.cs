using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Model.ValueObjects;
using ChaquitacllaError404.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.Crops.Domain.Repositories;

public interface IProductRepository: IBaseRepository<Product>
{
    /**
     * Method of the interface that allows to search for a product by its type
     */
    Task<IEnumerable<Product>> FindByTypeAsync(EProductType type);
    
}