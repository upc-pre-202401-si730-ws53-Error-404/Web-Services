using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Interfaces.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.Transform;

public static class SowingResourceFromEntityAssembler
{
    public static SowingResource ToResourceFromEntity(Sowing entity)
    {
        return new SowingResource(entity.Id,
            entity.StartDate,
            entity.EndDate, 
            entity.AreaLand,
            entity.Status,
            entity.PhenologicalPhase);
    }
}

