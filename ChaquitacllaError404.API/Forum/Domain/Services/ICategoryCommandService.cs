using ChaquitacllaError404.API.Forum.Domain.Model.Commands;
using ChaquitacllaError404.API.Forum.Domain.Model.Entities;

namespace ChaquitacllaError404.API.Forum.Domain.Services;

public interface ICategoryCommandService
{
    Task<Category?> Handle(CreateCategoryCommand command);
    Task<Category> Handle(UpdateCategoryCommand command);
    Task Handle(DeleteCategoryCommand command);
}