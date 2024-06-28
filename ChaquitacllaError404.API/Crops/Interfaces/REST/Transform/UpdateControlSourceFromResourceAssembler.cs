using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public class UpdateControlSourceFromResourceAssembler
{
    public static UpdateControlCommand ToCommandFromResource(UpdateControlResource resource,int sowingId, int sowingControlId ) {
        return new UpdateControlCommand(
            sowingId,
            sowingControlId,
            resource.SowingCondition,
            resource.StemCondition,
            resource.SoilMoisture
        );
    }
}