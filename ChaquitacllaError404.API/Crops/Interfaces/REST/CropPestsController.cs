using System.Net.Mime;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST;

[ApiController]
[Route("/api/v1/crops-management/crops")]
[Produces(MediaTypeNames.Application.Json)]
public class CropPestsController : ControllerBase
{
    private readonly IPestCommandService pestCommandService;
    private readonly IPestQueryService pestQueryService;

    public CropPestsController(IPestCommandService pestCommandService, IPestQueryService pestQueryService)
    {
        this.pestCommandService = pestCommandService;
        this.pestQueryService = pestQueryService;
    }

    [HttpPost("pests")]
    public async Task<ActionResult> CreatePest([FromBody] CreatePestResource resource)
    {
        var createPestCommand = CreatePestSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await pestCommandService.Handle(createPestCommand);
        return CreatedAtAction(nameof(GetPestById), new { id = result.Id },
            PestResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("pests/{id}")]
    public async Task<ActionResult> GetPestById(int id)
    {
        var getPestByIdQuery = new GetPestByIdQuery(id);
        var result = await pestQueryService.Handle(getPestByIdQuery);
        var resource = PestResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    
    
    [HttpGet("pests")]
    public async Task<ActionResult> GetAllPests()
    {
        var getAllPestsQuery = new GetAllPestsQuery();
        var pests = await pestQueryService.Handle(getAllPestsQuery);
        var resources = pests.Select(PestResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{cropId}/pests")]
    public async Task<ActionResult> GetPestsByCropId(int cropId)
    {
        try
        {
             
            var getPestsByCropIdQuery = new GetPestByCropIdQuery(cropId);
            var pests = await pestQueryService.Handle(getPestsByCropIdQuery);
            var resources = pests.Select(PestResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving pests for crop {cropId}: {ex.Message}");
            return BadRequest(new { error = ex.Message });
        }
    }

}