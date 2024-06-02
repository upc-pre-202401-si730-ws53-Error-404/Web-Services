using ChaquitacllaError404.API.Forum.Domain.Model.Commands;
using ChaquitacllaError404.API.Forum.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Forum.Interfaces.REST.Transform;

public static class CreateAnswerCommandFromResourceAssembler
{
    public static CreateAnswerCommand ToCommandFromResource(int authorId,int questionId,CreateAnswerResource resource)
    {
        return new CreateAnswerCommand(authorId, questionId, resource.AnswerText);
    }
}