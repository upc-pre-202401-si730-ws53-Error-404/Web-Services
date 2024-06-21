using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Interfaces.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.Transform;

public static class CreateCropSourceCommandFromResourceAssembler
{
    public static CreateCropCommand ToCommandFromResource(CreateCropResource resource)
    {
        return new CreateCropCommand(resource.Name, resource.ImageUrl, resource.Description);
    }
}