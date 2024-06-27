using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public static class ProductResourceFromEntityAssembler
{
    public static ProductResource ToResourceFromEntity(Product entity)
    {
        return new ProductResource(entity.Id, entity.Name, entity.Type.ToString());
    }
}