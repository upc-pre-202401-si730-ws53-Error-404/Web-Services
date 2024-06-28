using System.Net.Mime;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST;


[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SowingsController(ISowingCommandService sowingCommandService,
    ISowingQueryService sowingQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateSowing([FromBody] CreateSowingResource resource)
    {
        var createSowingCommand =
            CreateSowingSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await sowingCommandService.Handle(createSowingCommand);
        return CreatedAtAction(nameof(GetSowingById), new { id = result.Id },
                SowingResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateSowing(int id, [FromBody] UpdateSowingResource resource)
    {
        var updateSowingCommand = UpdateSowingSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await sowingCommandService.Handle(id, updateSowingCommand);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(SowingResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    [HttpGet("{id}")]
    public async Task<ActionResult> GetSowingById(int id)
    {
        var getSowingByIdQuery = new GetSowingByIdQuery(id);
        var result = await sowingQueryService.Handle(getSowingByIdQuery);
        var resource = SowingResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    private async Task<ActionResult> GetSowingByStatusQuery(bool status)
    {
        var getSowingByStatus = new GetSowingByStatusQuery(status);
        var result = await sowingQueryService.Handle(getSowingByStatus);
        var resources = result.Select(SowingResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet]
    public async Task<ActionResult> GetSowingsFromQuery([FromQuery] bool? status)
    {
        if (status.HasValue)
        {
            return await GetSowingByStatusQuery(status.Value);
        }
        else
        {
            return Ok();
        }
    }
}