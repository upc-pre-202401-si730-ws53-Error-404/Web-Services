using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public static class CreateCareSourceCommandFromResourceAssembler
{
    public static CreateCareCommand ToCommandFromResource(CreateCareResource resource)
    {
        return new CreateCareCommand(resource.Suggestion, resource.Date);
    }
}

