using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform
{
    public static class PestResourceFromEntityAssembler
    {
        public static PestResource ToResourceFromEntity(Pest entity)
        {
            return new PestResource(entity.Id, entity.Name, entity.Description, entity.Solution);
            
        }
    }
}