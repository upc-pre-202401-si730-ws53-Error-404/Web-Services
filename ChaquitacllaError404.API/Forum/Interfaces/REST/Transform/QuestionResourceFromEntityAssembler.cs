using ChaquitacllaError404.API.Forum.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Forum.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Forum.Interfaces.REST.Transform;

public static class QuestionResourceFromEntityAssembler
{
    public static QuestionResource ToResourceFromEntity(Question entity)
    {
        if (entity.QuestionText == null)
        {
            throw new ArgumentNullException(nameof(entity), "La entidad Question proporcionada no puede ser null.");
        }

        if (entity.CategoryId == null)
        {
            throw new ArgumentNullException(nameof(entity.AuthorId), "La propiedad AuthorId de la entidad Question no puede ser null.");
        }
        
        return new QuestionResource( 
            entity.Id,
            entity.AuthorId.Id,
            entity.CategoryId,
            entity.QuestionText,
            entity.Date
            );
    }
}