using ChaquitacllaError404.API.Forum.Domain.Model.Entities;
using ChaquitacllaError404.API.Forum.Domain.Model.Queries;
using ChaquitacllaError404.API.Forum.Domain.Repositories;
using ChaquitacllaError404.API.Forum.Domain.Services;

namespace ChaquitacllaError404.API.Forum.Application.QueryService;

public class AnswerQueryService(IAnswerRepository answerRepository) : IAnswerQueryService
{
    public async Task<IEnumerable<Answer>> Handle(GetAllAnswersQuery query)
    {
        return await answerRepository.ListAsync();
    }

    public async Task<Answer?> Handle(GetAnswerByIdQuery query)
    {
        return await answerRepository.FindByIdAsync(query.AnswerId);
    }

    public async Task<IEnumerable<Answer>> Handle(GetAllAnswersByQuestionId query)
    {
        return await answerRepository.ListByQuestionIdAsync(query.QuestionId);
    }
}