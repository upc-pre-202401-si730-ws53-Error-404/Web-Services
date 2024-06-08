using ChaquitacllaError404.API.Forum.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.Forum.Domain.Repositories;

public interface IQuestionRepository : IBaseRepository<Question>
{
    Task<IEnumerable<Question>> FindByUserIdAsync(int authorId);
    bool ExistsByQuestionText(string questionText);
}