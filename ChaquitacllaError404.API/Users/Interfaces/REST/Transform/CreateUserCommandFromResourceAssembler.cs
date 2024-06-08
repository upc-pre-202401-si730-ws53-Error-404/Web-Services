using ChaquitacllaError404.API.Users.Domain.Model.Commands;
using ChaquitacllaError404.API.Users.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Users.Interfaces.REST.Transform;

public static class CreateUserCommandFromResourceAssembler
{
    public static CreateUserCommand ToCommandFromResource(CreateUserResource resource)
    {
        return new CreateUserCommand(resource.FirstName, resource.LastName, resource.Email, resource.Password, resource.Price, resource.Description, resource.City, resource.Country);
    }
}