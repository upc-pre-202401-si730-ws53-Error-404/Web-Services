using ChaquitacllaError404.API.Forum.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Forum.Domain.Repositories;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChaquitacllaError404.API.Forum.Infrastructure.Persistence.EFC.Repositories;

public class QuestionRepository(AppDbContext context) : BaseRepository<Question>(context), IQuestionRepository
{
    public async Task<IEnumerable<Question>> FindByUserIdAsync(int authorId)
    {
        return await Context.Set<Question>().Where(q => q.AuthorId.Id == authorId).ToListAsync();
    }
}