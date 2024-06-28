using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public class CreateAddProductToSowingCommandFromResourceAssembler
{
    public static AddProductToSowingCommand toCommandFromResource(AddProductToSowingResource resource)
    {
        return new AddProductToSowingCommand(
            resource.SowingId,
            resource.ProductId,
            resource.Quantity,
            DateTime.Now
        );
    }
}