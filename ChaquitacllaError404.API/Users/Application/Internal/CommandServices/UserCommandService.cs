using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ChaquitacllaError404.API.Shared.Domain.Repositories;
using ChaquitacllaError404.API.Users.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Users.Domain.Model.Commands;
using ChaquitacllaError404.API.Users.Domain.Repositories;
using ChaquitacllaError404.API.Users.Domain.Services;
using Microsoft.IdentityModel.Tokens;

namespace ChaquitacllaError404.API.Users.Application.Internal.CommandServices;

public class UserCommandService : IUserCommandService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;

    public UserCommandService(IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
    }

    public async Task<User?> Handle(CreateUserCommand command, string firstName, string lastName, string email,
        int price, string description, string city, string country)
    {
        var user = new User(command);
        user.Password = User.EncryptPassword(command.Password);

        try
        {
            // Creamos el perfil asociado en el contexto profile
            // var profileId = await externalProfileService.CreateProfileAsync(string firstName, string lastName, string email, string subscription);
            //if (profileId == 0)
            //{
            //  throw new Exception("Failed to create profile.");
            //}

            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return user;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the User: {e.Message}");
            return null;
        }
    }

    public async Task<User?> Handle(CreateUserCommand command)
    {
        var user = new User(command);
        try
        {
            await _userRepository.AddAsync(user);
            await _unitOfWork.CompleteAsync();
            return user;
        } catch(Exception e)
        {
            Console.WriteLine($"An error occurred while creating the User: {e.Message}");
            return null;
        }
    }
}