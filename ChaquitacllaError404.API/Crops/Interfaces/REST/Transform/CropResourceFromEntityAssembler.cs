using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;
using System.Linq;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public static class CropResourceFromEntityAssembler
{
    public static CropResource ToResourceFromEntity(Crop entity)
    {
        var diseaseIds = entity.Diseases.Select(d => d.Id).ToList();
        var pestIds = entity.Pests.Select(p => p.Id).ToList();
        var careIds = entity.Cares.Select(c => c.Id).ToList();

        return new CropResource(entity.Id, entity.Name, entity.Description, entity.ImageUrl, diseaseIds, pestIds, careIds);
    }
}