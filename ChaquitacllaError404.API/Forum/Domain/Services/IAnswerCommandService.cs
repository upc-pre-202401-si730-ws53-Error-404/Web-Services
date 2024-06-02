using ChaquitacllaError404.API.Forum.Domain.Model.Commands;
using ChaquitacllaError404.API.Forum.Domain.Model.Entities;

namespace ChaquitacllaError404.API.Forum.Domain.Services;

public interface IAnswerCommandService
{
    Task<Answer?> Handle(CreateAnswerCommand command);
    Task<Answer> Handle(UpdateAnswerCommand command);
    Task Handle(DeleteAnswerCommand command);
}