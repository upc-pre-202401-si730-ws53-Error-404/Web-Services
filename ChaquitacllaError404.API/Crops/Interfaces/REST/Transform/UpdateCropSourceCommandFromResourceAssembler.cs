using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public class UpdateCropSourceCommandFromResourceAssembler
{
    public static UpdateCropCommand ToCommandFromResource(UpdateCropResource resource)
    {
        return new UpdateCropCommand(resource.Name, resource.Description);
    }
}