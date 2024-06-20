using ChaquitacllaError404.API.Profiles.Domain.Model.Commands;
using ChaquitacllaError404.API.Profiles.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Profiles.Domain.Model.Aggregates;

public partial class Profile
{
    public Profile()
    {
        Name = new PersonName();
        Email = new EmailAddress();
    }

    public Profile(string firstName, string lastName, string email, int cityId, int subscriptionId, int countryId, DateTime startDate, DateTime endDate)
    {
        Name = new PersonName(firstName, lastName);
        Email = new EmailAddress(email);
        CityId = cityId;
        SubscriptionId = subscriptionId;
        CountryId = countryId;
        StartDate = startDate;
        EndDate = endDate;
    }

    public Profile(CreateProfileCommand command)
    {
        Name = new PersonName(command.FirstName, command.LastName);
        Email = new EmailAddress(command.Email);
        CityId = command.CityId;
        SubscriptionId = command.SubscriptionId;
        CountryId = command.CountryId;
        StartDate = DateTime.Now;
        EndDate = DateTime.Now.AddMonths(1);
    }

    public int Id { get; }
    public int CityId { get; private set; }
    public int SubscriptionId { get; private set; }
    public int CountryId { get; private set; }
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public PersonName Name { get; private set; }
    public EmailAddress Email { get; private set; }

    public string FullName => Name.FullName;

    public string EmailAddress => Email.Address;

    public void UpdateProfile(string fullName, string emailAddress, int countryId, int cityId, int subscriptionId)
    {
        Name = new PersonName(fullName);
        Email = new EmailAddress(emailAddress);
        CountryId = countryId;
        CityId = cityId;
        SubscriptionId = subscriptionId;
    }
}