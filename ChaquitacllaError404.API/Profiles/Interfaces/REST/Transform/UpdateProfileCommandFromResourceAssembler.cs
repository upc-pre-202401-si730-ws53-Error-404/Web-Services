using ChaquitacllaError404.API.Profiles.Domain.Model.Commands;
using ChaquitacllaError404.API.Profiles.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Profiles.Interfaces.REST.Transform;

public static class UpdateProfileCommandFromResourceAssembler
{
    public static UpdateProfileCommand ToCommandFromResource(int profileId, UpdateProfileResource resource)
    {
        return new UpdateProfileCommand(
            profileId,
            resource.FullName,
            resource.EmailAddress,
            resource.CountryId,
            resource.CityId,
            resource.SubscriptionId
        );
    }
}