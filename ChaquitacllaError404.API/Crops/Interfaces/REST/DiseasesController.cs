using System.Net.Mime;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Resources;
using ChaquitacllaError404.API.Crops.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST;

[ApiController]
[Route("/api/v1/crops/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class DiseasesController : ControllerBase
{
    private readonly IDiseaseCommandService diseaseCommandService;
    private readonly IDiseaseQueryService diseaseQueryService;

    public DiseasesController(IDiseaseCommandService diseaseCommandService,
        IDiseaseQueryService diseaseQueryService)
    {
        this.diseaseCommandService = diseaseCommandService;
        this.diseaseQueryService = diseaseQueryService;
    }

    [HttpPost]
    public async Task<ActionResult> CreateDisease([FromBody] CreateDiseaseResource resource)
    {
        var createDiseaseCommand =
            CreateDiseaseSourceCommandFromResourceAssembler.ToCommandFromResource(resource);
        var result = await diseaseCommandService.Handle(createDiseaseCommand);
        return CreatedAtAction(nameof(GetDiseaseById), new { id = result.Id },
            DiseaseResourceFromEntityAssembler.ToResourceFromEntity(result));
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetDiseaseById(int id)
    {
        var getDiseaseByIdQuery= new GetDiseaseByIdQuery(id);
        var result = await diseaseQueryService.Handle(getDiseaseByIdQuery);
        var resource = DiseaseResourceFromEntityAssembler.ToResourceFromEntity(result);
        return Ok(resource);
    }
    
    [HttpGet]
    public async Task<ActionResult> GetAllDiseases()
    {
        try
        {
            var getAllDiseasesQuery = new GetAllDiseasesQuery();
            var diseases = await diseaseQueryService.Handle(getAllDiseasesQuery);
            var resources = diseases.Select(DiseaseResourceFromEntityAssembler.ToResourceFromEntity);
            return Ok(resources);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error retrieving diseases: {ex.Message}");
            return BadRequest(new { error = ex.Message });
        }
    }


}