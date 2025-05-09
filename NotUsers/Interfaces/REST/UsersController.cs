using System.Net.Mime;
using ChaquitacllaError404.API.Users.Domain.Model.Commands;
using ChaquitacllaError404.API.Users.Domain.Model.Queries;
using ChaquitacllaError404.API.Users.Domain.Services;
using ChaquitacllaError404.API.Users.Interfaces.REST.Resources;
using ChaquitacllaError404.API.Users.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ChaquitacllaError404.API.Users.Interfaces.REST;


[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class UsersController : ControllerBase
{
    private readonly IUserCommandService _userCommandService;
    private readonly IUserQueryService _userQueryService;

    public UsersController(IUserCommandService userCommandService, IUserQueryService userQueryService)
    {
        _userCommandService = userCommandService;
        _userQueryService = userQueryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllUsers()
    {
        var getAllUsersQuery = new GetAllUsersQuery();
        var users = await _userQueryService.Handle(getAllUsersQuery);
        if (users == null || !users.Any()) return NotFound();
        var userResources = users.Select(user => IUserResourceFromEntityAssembler.ToResourceFromEntity(user));
        return Ok(userResources);
    }
        
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserResource resource)
    {
        var createUserCommand = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var user = await _userCommandService.Handle(createUserCommand);
        if (user is null) return BadRequest();
        var userResource = IUserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return CreatedAtAction(nameof(GetUserById), new { userId = userResource.Id }, userResource);
    }

    [HttpGet("country/{country}")]
    public async Task<IActionResult> GetUserByCountry(string country)
    {
        var getUserByCountryQuery = new GetUserByCountryQuery(country);
        var users = await _userQueryService.Handle(getUserByCountryQuery);
        if (users == null || !users.Any()) return NotFound();
        var userResources = users.Select(user => IUserResourceFromEntityAssembler.ToResourceFromEntity(user));
        return Ok(userResources);
    }

    [HttpGet("city/{city}")]
    public async Task<IActionResult> GetUserByCity(string city)
    {
        var getUserByCityQuery = new GetUserByCityQuery(city);
        var users = await _userQueryService.Handle(getUserByCityQuery);
        if (users == null || !users.Any()) return NotFound();
        var userResources = users.Select(user => IUserResourceFromEntityAssembler.ToResourceFromEntity(user));
        return Ok(userResources);
    }
    
    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var user = await _userQueryService.Handle(getUserByIdQuery);
        if (user == null) return NotFound();
        var userResource = IUserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserResource resource)
    {
        var createUserCommand = new CreateUserCommand(resource.FirstName, resource.LastName, resource.Email,
            resource.Password, resource.City, resource.Country);
        
        var user = await _userCommandService.Handle(
            createUserCommand, resource.FirstName, resource.FirstName,
            resource.Email, resource.City, resource.Country);
        
        if (user == null) return BadRequest("An error occurred while creating the user.");
        
        var userResource = IUserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return CreatedAtAction(nameof(GetUserById), new {userId = userResource.Id}, userResource);
    }
}