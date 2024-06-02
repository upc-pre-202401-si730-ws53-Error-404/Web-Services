using ChaquitacllaError404.API.Forum.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Forum.Domain.Model.Commands;
using ChaquitacllaError404.API.Forum.Domain.Repositories;
using ChaquitacllaError404.API.Forum.Domain.Services;
using ChaquitacllaError404.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.Forum.Application.CommandServices;

public class QuestionCommandService(IQuestionRepository questionRepository, IUnitOfWork unitOfWork) : IQuestionCommandService
{
    public async Task<Question?> Handle(CreateQuestionCommand command)
    {
        var question = new Question(command);
        try
        {
            await questionRepository.AddAsync(question);
            await unitOfWork.CompleteAsync();
            return question;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the question: {e.Message}");
            return null;
        }
    }
    

    public async Task<Question> Handle(UpdateQuestionCommand command)
    {
        var question = await questionRepository.FindByIdAsync(command.QuestionId);
        if(question == null) throw new Exception("Question not found");
        question.UpdateInformation(command);
        try
        {
            questionRepository.Update(question);
            await unitOfWork.CompleteAsync();
            return question;
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while trying to update the question: {e.Message}");
            return null;
        }
    }

    public async Task Handle(DeleteQuestionCommand command)
    {
        var question = await questionRepository.FindByIdAsync(command.QuestionId);
        if(question == null) throw new Exception("Question not found");
        try
        {
            questionRepository.Remove(question);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine($"An error occurred while trying to delete the question: {e.Message}");
        }
        
        
    }
}