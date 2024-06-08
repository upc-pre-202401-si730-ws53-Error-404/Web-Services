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

public class UsersController(IUserCommandService userCommandService, IUserQueryService userQueryService):ControllerBase 
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserResource resource)
    {
        var createUserCommand = CreateUserCommandFromResourceAssembler.ToCommandFromResource(resource);
        var user = await userCommandService.Handle(createUserCommand);
        if (user is null) return BadRequest();
        var userResource = IUserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return CreatedAtAction(nameof(GetUserById), new {userId = userResource.Id}, userResource);
    }
    
    [HttpGet("{userId:int}")]
    public async Task<IActionResult> GetUserById(int userId)
    {
        var getUserByIdQuery = new GetUserByIdQuery(userId);
        var user = await userQueryService.Handle(getUserByIdQuery);
        if (user == null) return NotFound();
        var userResource = IUserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return Ok(userResource);
    }


    [HttpPost("Register")]
    public async Task<IActionResult> RegisterUser([FromBody] RegisterUserResource resource)
    {
        var createUserCommand =
            new CreateUserCommand(resource.FirstName, resource.LastName, resource.Email,
                resource.Password, resource.Price, resource.Description);
        
        var user = await userCommandService.Handle(createUserCommand, resource.FirstName, resource.FirstName,
            resource.Email, resource.Price, resource.Description);
        
        if (user==null) return BadRequest("An error occurred while creating the user.");
        
        var userResource = IUserResourceFromEntityAssembler.ToResourceFromEntity(user);
        return CreatedAtAction(nameof(GetUserById), new {userId = userResource.Id}, userResource);
    }
    [HttpPost("login")]
    public async Task<IActionResult> LoginUser([FromBody] LoginUserResource resource)
    {
        var loginUserCommand = new LoginUserCommand(resource.FirstName, resource.LastName, resource.Password);
        var token = await userCommandService.Handle(loginUserCommand);
        if (token == null) return Unauthorized();
        return Ok(new { token });
    }
}