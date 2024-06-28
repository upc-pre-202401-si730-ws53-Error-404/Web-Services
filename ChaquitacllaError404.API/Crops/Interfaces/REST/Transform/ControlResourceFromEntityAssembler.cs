using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public static class ControlResourceFromEntityAssembler
{
    public static ControlResource ToResourceFromEntity(Control entity)
    {
        return new ControlResource(entity.Id, entity.SowingId,  entity.Date, entity.SowingCondition.ToString(),entity.StemCondition.ToString(), entity.SoilMoisture.ToString());
    }
}