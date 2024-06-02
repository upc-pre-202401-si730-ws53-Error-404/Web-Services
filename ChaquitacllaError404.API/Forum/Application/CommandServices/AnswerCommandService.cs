using ChaquitacllaError404.API.Forum.Domain.Model.Commands;
using ChaquitacllaError404.API.Forum.Domain.Model.Entities;
using ChaquitacllaError404.API.Forum.Domain.Repositories;
using ChaquitacllaError404.API.Forum.Domain.Services;
using ChaquitacllaError404.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.Forum.Application.CommandServices;

public class AnswerCommandService(IAnswerRepository answerRepository, IQuestionRepository questionRepository, IUnitOfWork unitOfWork) : IAnswerCommandService
{
    public async Task<Answer?> Handle(CreateAnswerCommand command)
    {
        var answer = new Answer(command);
        var question = await questionRepository.FindByIdAsync(command.QuestionId);
        if(question == null) return null;
        answer.Question = question;
        try
        {
            await answerRepository.AddAsync(answer);
            await unitOfWork.CompleteAsync();
            return answer;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the answer: {e.Message}");
            return null;
        }
    }

    public async Task<Answer> Handle(UpdateAnswerCommand command)
    {
        var answer = await answerRepository.FindByIdAsync(command.AnswerId);
        if(answer == null) throw new Exception("Answer not found");
        answer.UpdateInformation(command);
        try
        {
            answerRepository.Update(answer);
            await unitOfWork.CompleteAsync();
            return answer;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while trying to update the answer: {e.Message}");
            throw;
        }
    }

    public async Task Handle(DeleteAnswerCommand command)
    {
        var answer = await answerRepository.FindByIdAsync(command.AnswerId);
        if(answer == null) throw new Exception("Answer not found");
        try
        {
            answerRepository.Remove(answer);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while trying to delete the answer: {e.Message}");
            throw;
        }
    }
}