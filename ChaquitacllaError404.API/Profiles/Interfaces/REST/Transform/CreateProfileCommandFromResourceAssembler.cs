using ChaquitacllaError404.API.Profiles.Domain.Model.Commands;
using ChaquitacllaError404.API.Profiles.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Profiles.Interfaces.REST.Transform;

public static class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommandFromResource(CreateProfileResource resource)
    {
        return new CreateProfileCommand(resource.FirstName, resource.LastName, resource.Email
            , resource.CountryId, resource.CityId, resource.SubscriptionId);
    }
}