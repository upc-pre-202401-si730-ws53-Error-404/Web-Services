namespace ChaquitacllaError404.API.Forum.Interfaces.REST.Resources;

public record CreateQuestionResource(int AuthorId ,string Category, string QuestionText);