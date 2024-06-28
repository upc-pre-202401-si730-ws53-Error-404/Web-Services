using System.Net.Mime;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST;


[ApiController]
[Route("/api/v1/crops")]
[Produces(MediaTypeNames.Application.Json)]
public class CaresController : ControllerBase
{
    private readonly ICareCommandService careCommandService;
    private readonly ICareQueryService careQueryService;

    public CaresController(ICareCommandService careCommandService,
        ICareQueryService careQueryService)
    {
        this.careCommandService = careCommandService;
        this.careQueryService= careQueryService;
    }

    [HttpPost("[controller]")]
    public async Task<ActionResult> CreateCare([FromBody] CreateCareResource resource)
    {
        var createCareCommand =
            CreateCareSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await careCommandService.Handle(createCareCommand);
        return CreatedAtAction(nameof(GetCareById), new { id = result.Id },
            CareResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    [HttpGet("[controller]/{id}")]
    public async Task<ActionResult> GetCareById(int id)
    {
        var getCareByIdQuery = new GetCareByIdQuery(id);
        var result = await careQueryService.Handle(getCareByIdQuery);
        var resource = CareResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet("{cropId}/[controller]")]
    public async Task<ActionResult> GetCaresByCropId(int cropId)
    {
        try
        {
            var getCaresByCropIdQuery = new GetCareByCropIdQuery(cropId);
            var cares = await careQueryService.Handle(getCaresByCropIdQuery);

            if (cares == null)
            {
                return NotFound($"No cares found for crop with id {cropId}");
            }

            var resources = cares.Select(CareResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving cares for crop {cropId}: {ex.Message}");
            return BadRequest(new { error = ex.Message });
        }
    }
}