using System.Net.Mime;
using ChaquitacllaError404.API.Forum.Domain.Model.Commands;
using ChaquitacllaError404.API.Forum.Domain.Model.Queries;
using ChaquitacllaError404.API.Forum.Domain.Services;
using ChaquitacllaError404.API.Forum.Interfaces.REST.Resources;
using ChaquitacllaError404.API.Forum.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;

namespace ChaquitacllaError404.API.Forum.Interfaces.REST;

[ApiController]
[Route("api/v1/forum/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
public class AnswersController(IAnswerCommandService answerCommandService, IAnswerQueryService answerQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateAnswer([FromBody] CreateAnswerResource createAnswerResource)
    {
        var createAnswerCommand = CreateAnswerCommandFromResourceAssembler.ToCommandFromResource(createAnswerResource);
        var answer = await answerCommandService.Handle(createAnswerCommand);
        if (answer is null) return BadRequest();
        var resource = AnswerResourceFromEntityAssembler.ToResourceFromEntity(answer);
        return CreatedAtAction(nameof(GetAnswerById), new { answerId = resource.AnswerId }, resource);
    }
    
    [HttpPut("{answerId}")]
    public async Task<ActionResult> UpdateQuestion([FromRoute] int answerId, [FromBody] UpdateAnswerResource updateAnswerResource)
    {
        var updateAnswerCommand = UpdateAnswerCommandFromResourceAssembler.ToCommandFromResource(answerId,updateAnswerResource);
        var answer = await answerCommandService.Handle(updateAnswerCommand);
        if (answer == null) return NotFound();
        var resource = AnswerResourceFromEntityAssembler.ToResourceFromEntity(answer);
        return Ok(resource);
    }
    
    [HttpDelete("{answerId}")]
    public async Task<ActionResult> DeleteAnswer([FromRoute] int answerId)
    {
        var deleteAnswerCommand = new DeleteAnswerCommand(answerId);
        await answerCommandService.Handle(deleteAnswerCommand);
        return Ok("Answer with given id successfully deleted.");
    }
    
    
    [HttpGet]
    public async Task<ActionResult> GetAllAnswers()
    {
        var getAllAnswersQuery = new GetAllAnswersQuery();
        var answers = await answerQueryService.Handle(getAllAnswersQuery);
        var resources = answers.Select(AnswerResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    [HttpGet("{answerId}")]
    public async Task<ActionResult> GetAnswerById([FromRoute] int answerId)
    {
        var answer = await answerQueryService.Handle(new GetAnswerByIdQuery(answerId));
        if (answer == null) return NotFound();
        var resource = AnswerResourceFromEntityAssembler.ToResourceFromEntity(answer);
        return Ok(resource);
    }
    
    
    [HttpGet("question/{questionId}")]
    public async Task<ActionResult> GetAnswersByQuestionId([FromRoute] int questionId)
    {
        var getAllAnswersByQuestionIdQuery = new GetAllAnswersByQuestionId(questionId);
        var answers = await answerQueryService.Handle(getAllAnswersByQuestionIdQuery);
        var resources = answers.Select(AnswerResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
}