using ChaquitacllaError404.API.Forum.Domain.Model.Commands;
using ChaquitacllaError404.API.Forum.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Forum.Interfaces.REST.Transform;

public class UpdateQuestionCommandFromResourceAssembler
{
    public static UpdateQuestionCommand ToCommandFromResource(int questionId,UpdateQuestionResource resource)
    {
        return new UpdateQuestionCommand(questionId, resource.Category, resource.Ask);
    }
}