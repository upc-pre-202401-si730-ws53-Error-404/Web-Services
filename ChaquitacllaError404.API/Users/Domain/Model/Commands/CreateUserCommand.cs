using ChaquitacllaError404.API.Users.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Users.Domain.Model.Commands;

public record CreateUserCommand(string FirstName, string LastName, string Email, string Password, Subscriptions Subscription);