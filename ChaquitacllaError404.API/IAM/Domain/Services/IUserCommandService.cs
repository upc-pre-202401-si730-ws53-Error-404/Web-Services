using ChaquitacllaError404.API.IAM.Domain.Model.Aggregates;
using ChaquitacllaError404.API.IAM.Domain.Model.Commands;

namespace ChaquitacllaError404.API.IAM.Domain.Services;

public interface IUserCommandService
{
    Task Handle(SignUpCommand command);
    Task<(User user, string token)> Handle(SignInCommand command);
}