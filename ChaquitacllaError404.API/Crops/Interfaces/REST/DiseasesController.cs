using System.Net.Mime;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Services;
using ChaquitacllaError404.API.Crops.Interfaces.Resources;
using ChaquitacllaError404.API.Crops.Interfaces.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ChaquitacllaError404.API.Crops.Interfaces.REST;


[ApiController]
[Route("/api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class DiseasesController (IDiseaseCommandService diseaseCommandService,
    IDiseaseQueryService diseaseQueryService)
    : ControllerBase
{
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
}
