using ChaquitacllaError404.API.Forum.Domain.Model.Entities;
using ChaquitacllaError404.API.Forum.Domain.Repositories;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ChaquitacllaError404.API.Forum.Infrastructure.Persistence.EFC.Repositories;

public class AnswerRepository(AppDbContext context) : BaseRepository<Answer>(context), IAnswerRepository
{
    public Task<IEnumerable<Answer>> ListByQuestionIdAsync(int questionId)
    {
        throw new NotImplementedException();
        // TODO: Implement this method
    }
}