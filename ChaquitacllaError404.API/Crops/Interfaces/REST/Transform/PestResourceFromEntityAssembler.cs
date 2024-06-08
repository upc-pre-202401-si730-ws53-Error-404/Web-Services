using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Interfaces.Resources;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.Transform
{
    public static class PestResourceFromEntityAssembler
    {
        public static PestResource ToResourceFromEntity(Pest entity)
        {
            if(entity == null)
            {
                throw new ArgumentException(nameof(entity), "The entity can not be null");
            }

            var crops = entity.Crops?.ToArray() ?? Array.Empty<Crop>();

            return new PestResource(entity.Id, entity.Name, entity.Description, crops);
        }
    }
}