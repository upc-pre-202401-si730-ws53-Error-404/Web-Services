using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public static class CropResourceFromEntityAssembler
{
    public static CropResource ToResourceFromEntity(Crop entity)
    {

        return new CropResource(entity.Id, entity.Name, entity.Description,entity.ImageUrl);
    }
}