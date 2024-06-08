using System.Net.Mime;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Crops.Interfaces.Resources;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;
using ChaquitacllaError404.API.Crops.Interfaces.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST;

[ApiController]
[Route("/api/v1/[controller]")]
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

    [HttpPost]
    public async Task<ActionResult> CreatePest([FromBody] CreatePestResource resource)
    {
        var createPestCommand = CreatePestSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await pestCommandService.Handle(createPestCommand);
        return CreatedAtAction(nameof(GetPestById), new { id = result.Id },
            PestResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetPestById(int id)
    {
        var getPestByIdQuery = new GetPestByIdQuery(id);
        var result = await pestQueryService.Handle(getPestByIdQuery);
        var resource = PestResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}