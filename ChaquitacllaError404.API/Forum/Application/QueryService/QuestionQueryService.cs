using ChaquitacllaError404.API.Forum.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Forum.Domain.Model.Queries;
using ChaquitacllaError404.API.Forum.Domain.Repositories;
using ChaquitacllaError404.API.Forum.Domain.Services;

namespace ChaquitacllaError404.API.Forum.Application.QueryService;

public class QuestionQueryService(IQuestionRepository questionRepository) : IQuestionQueryService
{
    public async Task<IEnumerable<Question>> Handle(GetAllQuestionsQuery query)
    {
        return await questionRepository.ListAsync();
    }

    public async Task<Question?> Handle(GetQuestionByIdQuery query)
    {
        return await questionRepository.FindByIdAsync(query.QuestionId);
    }

    public async Task<IEnumerable<Question>> Handle(GetAllQuestionsByUserId query)
    {
        return await questionRepository.ListByUserIdAsync(query.UserId);
    }
}