using ChaquitacllaError404.API.Forum.Domain.Model.Commands;
using ChaquitacllaError404.API.Forum.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Forum.Interfaces.REST.Transform;

public class UpdateAnswerCommandFromResourceAssembler
{
    public static UpdateAnswerCommand ToCommandFromResource(int answerId,UpdateAnswerResource resource)
    {
        return new UpdateAnswerCommand(answerId,resource.AnswerText);
    }
}