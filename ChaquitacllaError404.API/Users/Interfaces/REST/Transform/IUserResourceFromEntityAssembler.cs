using ChaquitacllaError404.API.Users.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Users.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Users.Interfaces.REST.Transform;

public interface IUserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(entity.Id, entity.FirstName, entity.LastName, entity.Email);
    }
}   