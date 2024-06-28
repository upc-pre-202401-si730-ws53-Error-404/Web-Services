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
public class PestsController : ControllerBase
{
    private readonly IPestCommandService pestCommandService;
    private readonly IPestQueryService pestQueryService;

    public PestsController(IPestCommandService pestCommandService, IPestQueryService pestQueryService)
    {
        this.pestCommandService = pestCommandService;
        this.pestQueryService = pestQueryService;
    }

    [HttpPost("[controller])")]
    public async Task<ActionResult> CreatePest([FromBody] CreatePestResource resource)
    {
        var createPestCommand = CreatePestSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await pestCommandService.Handle(createPestCommand);
        return CreatedAtAction(nameof(GetPestById), new { id = result.Id },
            PestResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("[controller]/{id}")]
    public async Task<ActionResult> GetPestById(int id)
    {
        var getPestByIdQuery = new GetPestByIdQuery(id);
        var result = await pestQueryService.Handle(getPestByIdQuery);
        var resource = PestResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet("{cropId}/[controller]")]
    public async Task<ActionResult> GetPestsByCropId(int cropId)
    {
        var getPestByCropIdQuery = new GetPestByCropIdQuery(cropId);
        var pests = await pestQueryService.Handle(getPestByCropIdQuery);
        var resources = pests.Select(PestResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("[controller]")]
    public async Task<ActionResult> GetAllPests()
    {
        var getAllPestsQuery = new GetAllPestsQuery();
        var pests = await pestQueryService.Handle(getAllPestsQuery);
        var resources = pests.Select(PestResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }

}