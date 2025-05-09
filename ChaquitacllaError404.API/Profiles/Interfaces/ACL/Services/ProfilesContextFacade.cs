using ChaquitacllaError404.API.Profiles.Domain.Model.Commands;
using ChaquitacllaError404.API.Profiles.Domain.Model.Querys;
using ChaquitacllaError404.API.Profiles.Domain.Model.ValueObjects;
using ChaquitacllaError404.API.Profiles.Domain.Services;

namespace ChaquitacllaError404.API.Profiles.Interfaces.ACL.Services;

public class ProfilesContextFacade(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService) : IProfilesContextFacade
{
    /**
     * Create a profile.
     *
     * <param name="firstName">The first name of the profile</param>
     * <param name="lastName">The last name of the profile</param>
     * <param name="email">The email of the profile</param>
     * <param name="cityId">The city id of the profile</param>
     * <param name="subscriptionId">The subscription id of the profile</param>
     * <param name="countryId">The country id of the profile</param>
     * <returns>The profile id</returns>
     *
     */
    public async Task<int> CreateProfile(string firstName, string lastName, string email, int cityId, int subscriptionId, int countryId)
    {
        var createProfileCommand = new CreateProfileCommand(firstName, lastName, email, cityId, subscriptionId, countryId);
        var profile = await profileCommandService.Handle(createProfileCommand);
        return profile?.Id ?? 0;
    }
    
    /**
     * Fetch a profile id by email.
     *
     * <param name="email">The email of the profile</param>
     * <returns>The profile id</returns>
     *
     */
    public async Task<int> FetchProfileIdByEmail(string email)
    {
        var getProfileByEmailQuery = new GetProfileByEmailQuery(new EmailAddress(email));
        var profile = await profileQueryService.Handle(getProfileByEmailQuery);
        return profile?.Id ?? 0;
    }
}