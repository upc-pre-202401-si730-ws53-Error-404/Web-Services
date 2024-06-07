using ChaquitacllaError404.API.Forum.Domain.Model.Entities;
using ChaquitacllaError404.API.Forum.Domain.Repositories;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChaquitacllaError404.API.Forum.Infrastructure.Persistence.EFC.Repositories;

public class AnswerRepository(AppDbContext context) : BaseRepository<Answer>(context), IAnswerRepository
{
    public async Task<IEnumerable<Answer>> FindByQuestionIdAsync(int questionId)
    {
        return await Context.Set<Answer>().Where(a => a.QuestionId == questionId).ToListAsync();
    }
}