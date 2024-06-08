using ChaquitacllaError404.API.Forum.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Forum.Domain.Model.Commands;

namespace ChaquitacllaError404.API.Forum.Domain.Services;

public interface IQuestionCommandService
{
    Task<Question?> Handle(CreateQuestionCommand command);
    Task<Question> Handle(UpdateQuestionCommand command);
    Task Handle(DeleteQuestionCommand command);
}