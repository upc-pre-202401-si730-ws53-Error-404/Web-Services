using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public static class SowingResourceFromEntityAssembler
{
    public static SowingResource ToResourceFromEntity(Sowing entity)
    {
        return new SowingResource(entity.Id,
            entity.StartDate,
            entity.EndDate, 
            entity.AreaLand,
            entity.Status,
            entity.PhenologicalPhase,
            entity.CropId);
    }
}

