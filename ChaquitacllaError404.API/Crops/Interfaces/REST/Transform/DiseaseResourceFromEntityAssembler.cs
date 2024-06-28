using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public static class DiseaseResourceFromEntityAssembler
{
    public static DiseaseResource ToResourceFromEntity(Disease entity)
    {
        return new DiseaseResource(entity.Id,
            entity.Name,
            entity.Description,
            entity.Solution);
    }
}