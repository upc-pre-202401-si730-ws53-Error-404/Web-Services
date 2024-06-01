using ChaquitacllaError404.API.Forum.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Forum.Domain.Repositories;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ChaquitacllaError404.API.Forum.Infrastructure.Persistence.EFC.Repositories;

public class QuestionRepository(AppDbContext context) : BaseRepository<Question>(context), IQuestionRepository
{
    

    public Task<IEnumerable<Question>> ListByUserIdAsync(int userId)
    {
        throw new NotImplementedException();
        // TODO: Implement this method
    }
    
}