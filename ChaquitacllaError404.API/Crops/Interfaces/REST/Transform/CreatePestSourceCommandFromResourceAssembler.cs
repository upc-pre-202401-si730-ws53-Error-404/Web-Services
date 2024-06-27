using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public static class CreatePestSourceCommandFromResourceAssembler
{
    public static CreatePestCommand ToCommandFromResource(CreatePestResource resource)
    {
        return new CreatePestCommand(resource.Name, resource.Description, resource.Solution, resource.CropIds);
    }
}