using System.Net.Mime;
using ChaquitacllaError404.API.Profiles.Domain.Model.Querys;
using ChaquitacllaError404.API.Profiles.Domain.Services;
using ChaquitacllaError404.API.Profiles.Interfaces.REST.Resources;
using ChaquitacllaError404.API.Profiles.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ChaquitacllaError404.API.Profiles.Interfaces.REST;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class ProfilesController(IProfileCommandService profileCommandService, IProfileQueryService profileQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateProfile(CreateProfileResource resource)
    {
        var createProfileCommand = CreateProfileCommandFromResourceAssembler.ToCommandFromResource(resource);
        var profile = await profileCommandService.Handle(createProfileCommand);
        if (profile is null) return BadRequest();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return CreatedAtAction(nameof(GetProfileById), new {profileId = profileResource.Id}, profileResource);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllProfiles()
    {
        var getAllProfilesQuery = new GetAllProfilesQuery();
        var profiles = await profileQueryService.Handle(getAllProfilesQuery);
        var profileResources = profiles.Select(ProfileResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(profileResources);
    }
    
    [HttpGet("{profileId:int}")]
    public async Task<IActionResult> GetProfileById(int profileId)
    {
        var getProfileByIdQuery = new GetProfileByIdQuery(profileId);
        var profile = await profileQueryService.Handle(getProfileByIdQuery);
        if (profile == null) return NotFound();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(profileResource);
    }
    
    [HttpPut("{profileId}")]
    public async Task<IActionResult> UpdateProfile(int profileId, UpdateProfileResource resource)
    {
        var updateProfileCommand = UpdateProfileCommandFromResourceAssembler.ToCommandFromResource(profileId, resource);
        var profile = await profileCommandService.Handle(updateProfileCommand);
        if (profile is null) return NotFound();
        var profileResource = ProfileResourceFromEntityAssembler.ToResourceFromEntity(profile);
        return Ok(profileResource);
    }
}