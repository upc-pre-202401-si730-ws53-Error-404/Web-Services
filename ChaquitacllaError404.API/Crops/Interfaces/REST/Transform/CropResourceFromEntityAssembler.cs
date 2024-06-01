using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Interfaces.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.Transform;

public static class CropResourceFromEntityAssembler
{
    public static CropResource ToResourceFromEntity(Crop entity)
{
    var diseaseIds = entity.Diseases.Select(d => d.Id).ToList();
    var pestIds = entity.Pests.Select(p => p.Id).ToList();

    return new CropResource(entity.Id, entity.Name, entity.Description, diseaseIds, pestIds);
}
}