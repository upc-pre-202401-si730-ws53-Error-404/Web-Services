using ChaquitacllaError404.API.Forum.Domain.Model.Commands;
using ChaquitacllaError404.API.Forum.Domain.Model.Entities;
using ChaquitacllaError404.API.Forum.Domain.Model.ValueObjects;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace ChaquitacllaError404.API.Forum.Domain.Model.Aggregates;

public class Question : IEntityWithCreatedUpdatedDate
{
    public int Id { get; }
    public string Category { get; private set; }
    public string QuestionText { get; private set;}
    public UserId AuthorId { get; }
    
    public ICollection<Answer> Answers { get;  }    
    
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }

    public Question()
    {
        AuthorId = new UserId(0);
        Category = string.Empty;
        QuestionText = string.Empty;
    }
    
    public Question(int authorId, string category, string questionText)
    {
        AuthorId = new UserId(authorId);
        Category = category;
        QuestionText = questionText;
    }

    public Question(CreateQuestionCommand command) : this(command.AuthorId, command.Category, command.QuestionText){ }

    public Question UpdateInformation(UpdateQuestionCommand command)
    {
        Category = command.Category;
        QuestionText = command.QuestionText;
        return this;
    }
    
}