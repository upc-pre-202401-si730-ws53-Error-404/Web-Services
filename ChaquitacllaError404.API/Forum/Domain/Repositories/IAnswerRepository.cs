using ChaquitacllaError404.API.Forum.Domain.Model.Entities;
using ChaquitacllaError404.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.Forum.Domain.Repositories;

public interface IAnswerRepository : IBaseRepository<Answer>
{
    Task<IEnumerable<Answer>> FindByQuestionIdAsync(int questionId);
}