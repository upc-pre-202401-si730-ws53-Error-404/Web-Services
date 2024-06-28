using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public class CareResourceFromEntityAssembler
{
    public static CareResource ToResourceFromEntity(Care entity)
    {
        return new CareResource(entity.Id, entity.Suggestion, entity.Date);
    }
}