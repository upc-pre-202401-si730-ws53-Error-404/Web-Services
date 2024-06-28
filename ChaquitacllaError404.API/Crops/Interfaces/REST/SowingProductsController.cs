using System.Net.Mime;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST;

[ApiController]
[Route("api/v1/crops-management/sowings")]
[Produces(MediaTypeNames.Application.Json)]
public class SowingProductsController(IProductCommandService productCommandService, ISowingQueryService sowingQueryService,
    ISowingCommandService sowingCommandService,
    IProductQueryService productQueryService, AppDbContext context) : ControllerBase
{

    /**
     * Method HTTP to get all products
     */
    [HttpGet("products")]
    public async Task<IActionResult> GetAllProducts()
    {
        var getAllProductsQuery = new GetAllProductsQuery();
        var products = await productQueryService.Handle(getAllProductsQuery);
        var resources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    /**
     * Method HTTP to get products by type
     */
    [HttpGet("products/{type}")]
    public async Task<IActionResult> GetProductsByType(string type)
    {
        var getProductsByTypeQuery = new GetProductsByTypeQuery(type);
        var products = await productQueryService.Handle(getProductsByTypeQuery);
        var resources = products.Select(ProductResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("products/{productId:int}")]
    public async Task<IActionResult> GetProductById(int productId)
    {
        var getProductByIdQuery = new GetProductByIdQuery(productId);
        var product = await productQueryService.Handle(getProductByIdQuery);
        if (product == null)
        {
            return NotFound();
        }
        var resource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return Ok(resource);
    }
    
    
    /**
     * Method HTTP POST to create a product.
     */
    [HttpPost("products")]
    public async Task<IActionResult> CreateProduct([FromBody] CreateProductResource resource)
    {
        var createProductCommand = CreateProductCommandFromResourceAssembler.ToCommandFromResource(resource);
        var product = await productCommandService.Handle(createProductCommand);
        var productResource = ProductResourceFromEntityAssembler.ToResourceFromEntity(product);
        return CreatedAtAction(nameof(GetProductById), new {ProductId = product.Id}, productResource);
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
    
}