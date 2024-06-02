using ChaquitacllaError404.API.Forum.Domain.Model.Commands;
using ChaquitacllaError404.API.Forum.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Forum.Interfaces.REST.Transform;

public static class CreateQuestionCommandFromResourceAssembler
{
    public static CreateQuestionCommand ToCommandFromResource(int authorId,CreateQuestionResource resource)
    {
        return new CreateQuestionCommand(authorId, resource.Category, resource.Ask);
    }
}