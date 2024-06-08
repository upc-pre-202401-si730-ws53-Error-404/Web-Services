using ChaquitacllaError404.API.Users.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Users.Interfaces.REST.Resources;

public record CreateUserResource(string FirstName, string LastName, string Email, string Password, int Price, string Description);