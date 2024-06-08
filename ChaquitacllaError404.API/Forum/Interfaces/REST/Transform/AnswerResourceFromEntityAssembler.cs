using ChaquitacllaError404.API.Forum.Domain.Model.Entities;
using ChaquitacllaError404.API.Forum.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Forum.Interfaces.REST.Transform;

public static class AnswerResourceFromEntityAssembler
{
    public static AnswerResource ToResourceFromEntity(Answer entity)
    {
        return new AnswerResource(
            entity.Id,
            entity.AuthorId.Id,
            entity.QuestionId,
            entity.AnswerText
        );
    }
}