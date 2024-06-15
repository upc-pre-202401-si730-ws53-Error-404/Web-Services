using ChaquitacllaError404.API.Forum.Domain.Model.Entities;
using ChaquitacllaError404.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.Forum.Domain.Repositories;

public interface ICategoryRepository : IBaseRepository<Category>
{
    bool ExistsByCategoryName(string name);
}