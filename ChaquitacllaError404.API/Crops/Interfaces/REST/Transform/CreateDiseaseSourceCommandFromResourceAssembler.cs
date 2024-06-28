using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public static class CreateDiseaseSourceCommandFromResourceAssembler
{
    public static CreateDiseaseCommand ToCommandFromResource(CreateDiseaseResource resource)
    {
        return new CreateDiseaseCommand(resource.Name, resource.Description, resource.Solution);
    }
}