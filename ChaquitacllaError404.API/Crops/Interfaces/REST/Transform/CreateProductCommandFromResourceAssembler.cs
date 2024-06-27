using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Model.ValueObjects;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public static class CreateProductCommandFromResourceAssembler
{
    public static CreateProductCommand ToCommandFromResource(CreateProductResource resource)
    {
        if( Enum.TryParse<EProductType>(resource.Type, out var type))
        {
            return new CreateProductCommand(resource.Name, type);
        }
        else
        {
            throw new ArgumentException("Invalid product type");
        }
    }
}