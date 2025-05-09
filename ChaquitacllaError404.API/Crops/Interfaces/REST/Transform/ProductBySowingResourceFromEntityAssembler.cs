using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public class ProductBySowingResourceFromEntityAssembler
{
    public static ProductBySowingResource ToResourceFromEntity(ProductsBySowing entity)
    {
        return new ProductBySowingResource( entity.UseDate, entity.Quantity);
    }
}