using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public static class CreateControlSourceCommandFromResourceAssembler
{
    public static CreateControlCommand ToCommandFromResource(int SowingId, CreateControlResource resource)
    {
        return new CreateControlCommand(resource.SowingId, resource.SowingCondition, resource.SowingSoilMoisture, resource.SowingStemCondition);
    }
}