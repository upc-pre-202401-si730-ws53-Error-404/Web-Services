using ChaquitacllaError404.API.Forum.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Forum.Domain.Model.Commands;
using ChaquitacllaError404.API.Forum.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Forum.Domain.Model.Entities;

public class Answer
{
    public int Id { get; }
    public string AnswerText { get; private set; }
    public UserId AuthorId { get; }
    public Question Question { get; set; }
    public int QuestionId { get; private set; }

    public Answer()
    {
        AuthorId = new UserId(1);
        AnswerText = string.Empty;
    }
    public Answer(int authorId,int questionId, string answerText)
    {
        AuthorId = new UserId(authorId);
        QuestionId = questionId;
        AnswerText = answerText;
    }
    
    public Answer(CreateAnswerCommand command) : this(command.AuthorId, command.QuestionId, command.AnswerText){ }
    
    public Answer UpdateInformation(UpdateAnswerCommand command)
    {
        AnswerText = command.AnswerText;
        return this;
    }
}