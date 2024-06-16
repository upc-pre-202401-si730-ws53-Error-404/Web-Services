using ChaquitacllaError404.API.Profiles.Domain.Model.ValueObjects;
using ChaquitacllaError404.API.Profiles.Interfaces.ACL;

namespace ChaquitacllaError404.API.Profiles.Application.Internal.OutboundServices.ACL;

public class ExternalProfileService(IProfilesContextFacade profilesContextFacade)
{

    public async Task<ProfileId?> FetchProfileIdByEmail(string email)
    {
        var profileId = await profilesContextFacade.FetchProfileIdByEmail(email);
        if (profileId == 0) return await Task.FromResult<ProfileId?>(null);
        return new ProfileId(profileId);
    }

    public async Task<ProfileId?> CreateProfile(string firstName, string lastName, string email, int cityId,
        int subscriptionId,
        int countryId)
    {
        var profileId =
            await profilesContextFacade.CreateProfile(firstName, lastName, email, cityId, subscriptionId, countryId);
        if (profileId == 0) return await Task.FromResult<ProfileId?>(null);
        return new ProfileId(profileId);
    }
}