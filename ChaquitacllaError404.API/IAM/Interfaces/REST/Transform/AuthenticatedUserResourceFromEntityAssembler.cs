using ChaquitacllaError404.API.IAM.Domain.Model.Aggregates;
using ChaquitacllaError404.API.IAM.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.IAM.Interfaces.REST.Transform;

public static class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User entity, string token)
    {
        return new AuthenticatedUserResource(entity.Id, entity.Username, token);
    } 
}