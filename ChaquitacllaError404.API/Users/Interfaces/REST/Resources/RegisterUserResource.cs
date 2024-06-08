namespace ChaquitacllaError404.API.Users.Interfaces.REST.Resources;

public record RegisterUserResource(string FirstName, string LastName, string Password, string Email, int Price, string Description); // Agregar más parametros, Profile + User