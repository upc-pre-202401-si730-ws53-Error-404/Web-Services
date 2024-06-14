using ChaquitacllaError404.API.IAM.Domain.Model.Commands;
using ChaquitacllaError404.API.IAM.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}