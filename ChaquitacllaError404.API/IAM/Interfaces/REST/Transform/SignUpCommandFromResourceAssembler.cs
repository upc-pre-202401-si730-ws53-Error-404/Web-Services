using ChaquitacllaError404.API.IAM.Domain.Model.Commands;
using ChaquitacllaError404.API.IAM.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }

}