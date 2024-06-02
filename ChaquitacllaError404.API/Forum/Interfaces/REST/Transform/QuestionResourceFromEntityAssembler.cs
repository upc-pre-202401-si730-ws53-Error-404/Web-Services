using ChaquitacllaError404.API.Forum.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Forum.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Forum.Interfaces.REST.Transform;

public static class QuestionResourceFromEntityAssembler
{
    public static QuestionResource ToResourceFromEntity(Question entity)
    {
        return new QuestionResource( 
            entity.Id, 
            entity.AuthorId.Id,
            entity.Category, 
            entity.Ask
            );
    }
}