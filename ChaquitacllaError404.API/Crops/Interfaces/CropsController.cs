using System.Net.Mime;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Interfaces.Resources;
using ChaquitacllaError404.API.Crops.Interfaces.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ChaquitacllaError404.API.Crops.Interfaces;


[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CropsController (ICropCommandService cropCommandService,
    ICropQueryService cropQueryService)
    : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateCrop([FromBody] CreateCropResource resource)
    {
        var createCropCommand =
            CreateCropSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await cropCommandService.Handle(createCropCommand);
        return CreatedAtAction(nameof(GetCropById), new { id = result.Id },
            CropResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetCropById(int id)
    {
        var getCropByIdQuery = new GetCropByIdQuery(id);
        var result = await cropQueryService.Handle(getCropByIdQuery);
        var resource = CropResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
}
