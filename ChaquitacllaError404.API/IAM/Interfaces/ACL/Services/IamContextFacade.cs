using ChaquitacllaError404.API.IAM.Domain.Model.Commands;
using ChaquitacllaError404.API.IAM.Domain.Model.Queries;
using ChaquitacllaError404.API.IAM.Domain.Services;

namespace ChaquitacllaError404.API.IAM.Interfaces.ACL.Services;

public class IamContextFacade(
    IUserQueryService userQueryService, 
    IUserCommandService userCommandService) : IIamContextFacade
{
    public async Task<int> CreateUser(string username, string password)
    {
        var signUpCommand = new SignUpCommand(username, password);
        await userCommandService.Handle(signUpCommand);
        var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);
        return result?.Id ?? 0;
    }

    public async Task<int> FetchUserIdByUsername(string username)
    {
        var getUserByUsernameQuery = new GetUserByUsernameQuery(username);
        var result = await userQueryService.Handle(getUserByUsernameQuery);
        return result?.Id ?? 0;
    }

    public async Task<string> FetchUsernameByUserId(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var result = await userQueryService.Handle(getUserByIdQuery);
        return result?.Username ?? string.Empty;
    }
}