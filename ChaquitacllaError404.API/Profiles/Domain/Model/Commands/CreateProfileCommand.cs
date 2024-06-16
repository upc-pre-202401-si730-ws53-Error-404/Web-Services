namespace ChaquitacllaError404.API.Profiles.Domain.Model.Commands;

public record CreateProfileCommand(string FirstName, string LastName, string Email, int CityId, int SubscriptionId, int CountryId);