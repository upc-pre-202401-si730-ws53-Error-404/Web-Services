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
public class QuestionsController(IQuestionCommandService questionCommandService, IQuestionQueryService questionQueryService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult> CreateQuestion([FromBody] CreateQuestionResource createQuestionResource)
    {
        var createQuestionCommand = CreateQuestionCommandFromResourceAssembler.ToCommandFromResource(createQuestionResource);
        var question = await questionCommandService.Handle(createQuestionCommand);
        if (question is null) return BadRequest();
        var resource = QuestionResourceFromEntityAssembler.ToResourceFromEntity(question);
        return CreatedAtAction(nameof(GetQuestionById), new { questionId = resource.QuestionId }, resource);
    }
    
    [HttpPut("{questionId}")]
    public async Task<ActionResult> UpdateQuestion([FromRoute] int questionId, [FromBody] UpdateQuestionResource updateQuestionResource)
    {
        var updateQuestionCommand = UpdateQuestionCommandFromResourceAssembler.ToCommandFromResource( updateQuestionResource);
        var question = await questionCommandService.Handle(questionId, updateQuestionCommand);
        if (question == null) return NotFound();
        var resource = QuestionResourceFromEntityAssembler.ToResourceFromEntity(question);
        return Ok(resource);
    }
    
    [HttpDelete("{questionId}")]
    public async Task<ActionResult> DeleteQuestion([FromRoute] int questionId)
    {
        var deleteQuestionCommand = new DeleteQuestionCommand(questionId);
        await questionCommandService.Handle(deleteQuestionCommand);
        return Ok("Question with given id successfully deleted.");
    }
    
    
    
    [HttpGet]
    public async Task<ActionResult> GetAllQuestions()
    {
        var getAllQuestionsQuery = new GetAllQuestionsQuery();
        var questions = await questionQueryService.Handle(getAllQuestionsQuery);
        var resources = questions.Select(QuestionResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(resources);
    }
    
    
    [HttpGet("{questionId}")]
    public async Task<ActionResult> GetQuestionById([FromRoute] int questionId)
    {
        var question = await questionQueryService.Handle(new GetQuestionByIdQuery(questionId));
        if (question == null) return NotFound();
        var resource = QuestionResourceFromEntityAssembler.ToResourceFromEntity(question);
        return Ok(resource);
    }
    
}