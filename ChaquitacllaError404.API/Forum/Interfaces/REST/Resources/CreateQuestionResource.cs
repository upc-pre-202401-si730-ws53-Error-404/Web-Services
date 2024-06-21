namespace ChaquitacllaError404.API.Forum.Interfaces.REST.Resources;

public record CreateQuestionResource(int AuthorId ,int CategoryId, string QuestionText, DateOnly Date);