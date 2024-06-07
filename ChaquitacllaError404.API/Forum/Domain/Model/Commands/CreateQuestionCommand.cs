namespace ChaquitacllaError404.API.Forum.Domain.Model.Commands;

public record CreateQuestionCommand(int AuthorId, string Category, string QuestionText);