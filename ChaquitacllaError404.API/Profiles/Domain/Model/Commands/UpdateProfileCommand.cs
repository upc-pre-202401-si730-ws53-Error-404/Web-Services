namespace ChaquitacllaError404.API.Profiles.Domain.Model.Commands;

public record UpdateProfileCommand(int ProfileId, string FullName, string EmailAddress, int CountryId, int CityId, int SubscriptionId);