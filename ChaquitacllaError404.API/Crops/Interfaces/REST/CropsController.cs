using System.Net.Mime;
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
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateCrop(int id, [FromBody] UpdateCropResource resource)
    {
        var updateCropCommand = UpdateCropSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await cropCommandService.Handle(id, updateCropCommand);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(CropResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    /**
     * Method HTTP to get all products
     */
    [HttpGet]
    public async Task<IActionResult> GetAllCrops()
    {
        var getAllCropsQuery = new GetAllCropsQuery();
        var crops = await cropQueryService.Handle(getAllCropsQuery);
        var resources = crops.Select(CropResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}
