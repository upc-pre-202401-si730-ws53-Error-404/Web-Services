using System.Net.Mime;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST;

[ApiController]
[Route("/api/v1/crops-management/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class CropsController : ControllerBase
{
    private readonly ICropCommandService cropCommandService;
    private readonly ICropQueryService cropQueryService;
    private readonly ISowingQueryService sowingQueryService;

    public CropsController(ICropCommandService cropCommandService, ICropQueryService cropQueryService, ISowingQueryService sowingQueryService)
    {
        this.cropCommandService = cropCommandService;
        this.cropQueryService = cropQueryService;
        this.sowingQueryService = sowingQueryService;
    }

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
        if (result == null)
        {
            return NotFound();
        }
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

    [HttpGet]
    public async Task<IActionResult> GetAllCrops()
    {
        try
        {
            var getAllCropsQuery = new GetAllCropsQuery();
            var crops = await cropQueryService.Handle(getAllCropsQuery);
            if (crops == null)
            {
                return Ok(new List<CropResource>());
            }
            var resources = crops.Select(CropResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving crops: {ex.Message}");
            return BadRequest(new { error = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCrop(int id)
    {
        var result = await cropCommandService.DeleteCrop(id);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(CropResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
    /*[HttpPost("sowings")]
    public async Task<ActionResult> CreateSowingFromCrop([FromBody] CreateSowingResource resource)
    {
        var createSowingCommand = CreateSowingSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await cropCommandService.HandleCreateSowing(createSowingCommand);
        return CreatedAtAction(nameof(GetCropById), new { id = result.Id },
            SowingResourceFromEntityAssembler.ToResourceFromEntity(result));
    }*/
    
    /*
    [HttpGet("sowings/{id}")]
    public async Task<IActionResult> GetSowingById(int id)
    {
        try
        {
            var getSowingByIdQuery = new GetSowingByIdQuery(id);
            var sowing = await sowingQueryService.Handle(getSowingByIdQuery);
            var resource = SowingResourceFromEntityAssembler.ToResourceFromEntity(sowing);
            return Ok(resource);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving sowing: {ex.Message}");
            return BadRequest(new { error = ex.Message });
        }
    }*/

}
