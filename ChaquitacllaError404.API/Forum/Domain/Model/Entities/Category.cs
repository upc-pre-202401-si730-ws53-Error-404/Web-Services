using ChaquitacllaError404.API.Forum.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Forum.Domain.Model.Commands;

namespace ChaquitacllaError404.API.Forum.Domain.Model.Entities;

public class Category
{
    public int Id { get; private set; }
    public string Name { get; private set; }
    public ICollection<Question> Questions { get; private set; }
    
    
    public Category(){ }
    
    public Category(string name)
    {
        Name = name;
    }
    
    public Category(CreateCategoryCommand command) : this(command.Name) { }
    
    public Category UpdateInformation(UpdateCategoryCommand command)
    {
        Name = command.Name;
        return this;
    }
}