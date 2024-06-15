using ChaquitacllaError404.API.Forum.Domain.Model.Commands;
using ChaquitacllaError404.API.Forum.Domain.Model.Entities;
using ChaquitacllaError404.API.Forum.Domain.Model.ValueObjects;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace ChaquitacllaError404.API.Forum.Domain.Model.Aggregates;

public class Question : IEntityWithCreatedUpdatedDate
{
    public int Id { get; }
    public string QuestionText { get; private set;}
    public UserId AuthorId { get; }
    
    public Category Category { get;  set; }
    public int CategoryId { get; private set; }
    public ICollection<Answer> Answers { get;  }    
    
    
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }

    public Question()
    {
        AuthorId = new UserId(0);
        QuestionText = string.Empty;
    }
    
    public Question(int authorId, int categoryId, string questionText)
    {
        AuthorId = new UserId(authorId);
        CategoryId = categoryId;
        QuestionText = questionText;
    }

    public Question(CreateQuestionCommand command) : this(command.AuthorId, command.CategoryId, command.QuestionText){ }

    public Question UpdateInformation(UpdateQuestionCommand command)
    {
        CategoryId = command.CategoryId;
        QuestionText = command.QuestionText;
        return this;
    }
    
}