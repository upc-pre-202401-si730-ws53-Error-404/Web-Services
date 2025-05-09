using ChaquitacllaError404.API.Forum.Domain.Model.Entities;
using ChaquitacllaError404.API.Forum.Interfaces.REST.Resources;

namespace ChaquitacllaError404.API.Forum.Interfaces.REST.Transform;

public static class CategoryResourceFromEntityAssembler
{
    public static CategoryResource ToResourceFromEntity(Category entity)
    {
        return new CategoryResource(entity.Id, entity.Name);
    }
}