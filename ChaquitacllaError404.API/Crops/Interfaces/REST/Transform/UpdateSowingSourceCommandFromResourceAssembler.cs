using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public class UpdateSowingSourceCommandFromResourceAssembler
{
    public static UpdateSowingCommand ToCommandFromResource(UpdateSowingResource resource)
    {
        return new UpdateSowingCommand(resource.AreaLand,resource.CropId);
    }
}