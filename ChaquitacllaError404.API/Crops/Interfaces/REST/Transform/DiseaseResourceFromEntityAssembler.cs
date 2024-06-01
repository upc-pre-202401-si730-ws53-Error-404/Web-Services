using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Interfaces.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.Transform;

public class DiseaseResourceFromEntityAssembler
{
    public static DiseaseResource ToResourceFromEntity(Disease entity)
    {
        return new DiseaseResource(entity.Id,
            entity.Name,
            entity.Description,
            entity.Crops.Select(c => c.Id).ToList());
    }
}