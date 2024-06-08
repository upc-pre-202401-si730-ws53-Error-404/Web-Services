using ChaquitacllaError404.API.Users.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Users.Interfaces.REST.Resources;

public record UserResource(int Id, string FirstName, string LastName, string Email, Subscriptions Subscription);