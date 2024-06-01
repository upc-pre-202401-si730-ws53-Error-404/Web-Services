using ChaquitacllaError404.API.Forum.Domain.Model.Commands;
using ChaquitacllaError404.API.Forum.Domain.Model.ValueObjects;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace ChaquitacllaError404.API.Forum.Domain.Model.Aggregates;

public class Question : IEntityWithCreatedUpdatedDate
{
    public int Id { get; }
    public string Category { get; private set; }
    public string Ask { get; private set;}
    public UserId AuthorId { get; }
    public DateTimeOffset? CreatedDate { get; set; }
    public DateTimeOffset? UpdatedDate { get; set; }

    public Question()
    {
        Category = string.Empty;
        Ask = string.Empty;
    }
    
    public Question(string category, string ask)
    {
        Category = category;
        Ask = ask;
    }

    public Question(CreateQuestionCommand command) : this(command.Category, command.Ask){ }

    public Question UpdateInformation(UpdateQuestionCommand command)
    {
        Category = command.Category;
        Ask = command.Ask;
        return this;
    }
    
}