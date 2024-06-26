using System.Net.Mime;
using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Interfaces.Resources;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;
using ChaquitacllaError404.API.Crops.Interfaces.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ChaquitacllaError404.API.Crops.Interfaces;


[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SowingsController(ISowingCommandService sowingCommandService,
    ISowingQueryService sowingQueryService, IControlCommandService controlCommandService
    , IControlQueryService controlQueryService)
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
    
    [HttpGet("controls/{id}")]
    public async Task<ActionResult> GetControlById(int id)
    {
        var getControlByIdQuery = new GetControlByIdQuery(id);
        var result = await controlQueryService.Handle(getControlByIdQuery);
        var resource = ControlResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpPost("{sowingId}/controls")]
    public async Task<ActionResult> CreateControl(int sowingId, [FromBody] CreateControlResource resource)
    {
        var createControlCommand = CreateControlSourceCommandFromResourceAssembler.ToCommandFromResource(sowingId, resource);
        var result = await controlCommandService.Handle(createControlCommand);
        return CreatedAtAction(nameof(GetControlById), new { id = result.Id },
            ControlResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    /**
     * Delete method HTTP 
     */
    [HttpDelete("{id:int}")]
    public async Task<ActionResult> DeleteSowing(int id)
    {
        var deleteSowingCommand = new DeleteSowingCommand(id);
        var result = await sowingCommandService.Handle(deleteSowingCommand);
        if (!result)
        {
            return NotFound();
        }
    
        return Ok("Sowing deleted successful!");
    }
}