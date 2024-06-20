namespace ChaquitacllaError404.API.Profiles.Interfaces.ACL;

public interface IProfilesContextFacade
{
    Task<int> CreateProfile(string firstName, string lastName, string email, int cityId, int subscriptionId,
        int countryId);

    Task<int> FetchProfileIdByEmail(string email);
}