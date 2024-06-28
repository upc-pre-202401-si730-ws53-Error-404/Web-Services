using System.Net.Mime;
using ChaquitacllaError404.API.Crops.Domain.Model.Commands;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST;



//[Route("/api/v1/sowings/{sowingId}/controls")] SowingControlsController


[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class SowingsController(ISowingCommandService sowingCommandService,
    ISowingQueryService sowingQueryService, IControlCommandService controlCommandService
    , IControlQueryService controlQueryService,
    AppDbContext context
    )
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
    
    /*private async Task<ActionResult> GetSowingByStatusQuery(bool status)
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
      */
    [HttpGet]
    public async Task<ActionResult> GetAllSowings()
    {
        try
        {
            var getAllSowingsQuery = new GetAllSowingsQuery();
            var sowings = await sowingQueryService.Handle(getAllSowingsQuery);
            var resources = sowings.Select(SowingResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving sowings: {ex.Message}");
            return BadRequest(new { error = ex.Message });
        }
    }
    
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

    [HttpGet("{sowingId:int}/products")]
    public async Task<IActionResult> GetProductsBySowing(int sowingId)
    {
        var getSowingWithProductsQuery = new GetProductsBySowingQuery(sowingId);
        var result = await sowingQueryService.Handle(getSowingWithProductsQuery);
        if (!result.Any())
            return NotFound();
        
        var resultList = result.ToList();
        var resources = resultList.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        
        return Ok(resources);
    }
    
    [HttpPost("{sowingId:int}/products")]
    public async Task<IActionResult> AddProductToSowing(int sowingId, [FromBody] AddProductToSowingResource resource)
    {
        var command = CreateAddProductToSowingCommandFromResourceAssembler.toCommandFromResource(resource);

        var product = await sowingCommandService.Handle(command);

        return Ok(product);
    }
    
    [HttpGet("{sowingId}/products/{productId}")]
    public async Task<ActionResult<ProductBySowingResource>> GetProductBySowingDateAndQuantity(int sowingId, int productId)
    {
        var productBySowing = await context.Set<ProductsBySowing>()
            .FirstOrDefaultAsync(pbs => pbs.SowingId == sowingId && pbs.Product.Id == productId);

        if (productBySowing == null)

    [HttpPut("{id}/phenologicalphase")]
    public async Task<ActionResult> UpdatePhenologicalPhaseBySowingId(int id)
    {
        var updatePhenologicalPhaseBySowingIdCommand = new UpdatePhenologicalPhaseBySowingIdCommand(id);
        var result = await sowingCommandService.Handle(updatePhenologicalPhaseBySowingIdCommand);
        if (result == null)

        {
            return NotFound();
        }


        var resource = new ProductBySowingResource(productBySowing.UseDate, productBySowing.Quantity);

        return Ok(resource);
    }
    
    [HttpDelete("{sowingId}/products/{productId}")]
    public async Task<ActionResult> DeleteProductBySowing(int sowingId, int productId)
    {
        var productBySowing = await context.Set<ProductsBySowing>()
            .FirstOrDefaultAsync(pbs => pbs.SowingId == sowingId && pbs.Product.Id == productId);

        if (productBySowing == null)
        {
            return NotFound();
        }

        context.Set<ProductsBySowing>().Remove(productBySowing);
        await context.SaveChangesAsync();

        return Ok();
    }
        return Ok(SowingResourceFromEntityAssembler.ToResourceFromEntity(result));
    }
    
}