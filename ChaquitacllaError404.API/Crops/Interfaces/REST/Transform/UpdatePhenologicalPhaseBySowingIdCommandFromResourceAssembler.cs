using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;

public class UpdatePhenologicalPhaseBySowingIdCommandFromResourceAssembler
{
    public static UpdatePhenologicalPhaseBySowingIdCommand ToCommand(UpdatePhenologicalPhaseBySowingIdResource resource)
    {
        return new UpdatePhenologicalPhaseBySowingIdCommand(resource.Id);
    }
}