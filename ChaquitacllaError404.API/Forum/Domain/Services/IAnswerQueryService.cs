using ChaquitacllaError404.API.Forum.Domain.Model.Entities;
using ChaquitacllaError404.API.Forum.Domain.Model.Queries;

namespace ChaquitacllaError404.API.Forum.Domain.Services;

public interface IAnswerQueryService
{
    Task<IEnumerable<Answer>> Handle(GetAllAnswersQuery query);
    Task<Answer?> Handle(GetAnswerByIdQuery query);
    Task<IEnumerable<Answer>> Handle(GetAllAnswersByQuestionId query);
}