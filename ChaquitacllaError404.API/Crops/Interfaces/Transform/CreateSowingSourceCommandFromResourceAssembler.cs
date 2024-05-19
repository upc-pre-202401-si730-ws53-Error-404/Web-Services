using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Interfaces.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.Transform;

public static class CreateSowingSourceCommandFromResourceAssembler
{
    public static CreateSowingCommand ToCommandFromResource(CreateSowingResource resource)
    {
        return new CreateSowingCommand(resource.StartDate, resource.EndDate, resource.AreaLand);
    }
}