using ChaquitacllaError404.API.Forum.Domain.Model.Entities;
using ChaquitacllaError404.API.Forum.Domain.Model.Queries;
using ChaquitacllaError404.API.Forum.Domain.Repositories;
using ChaquitacllaError404.API.Forum.Domain.Services;


namespace ChaquitacllaError404.API.Forum.Application.QueryService;

public class CategoryQueryService(ICategoryRepository categoryRepository) : ICategoryQueryService
{
    public async Task<IEnumerable<Category>> Handle(GetAllCategoriesQuery query)
    {
        return await categoryRepository.ListAsync();
    }

    public async Task<Category?> Handle(GetCategoryByIdQuery query)
    {
        return await categoryRepository.FindByIdAsync(query.CategoryId);
    }
}