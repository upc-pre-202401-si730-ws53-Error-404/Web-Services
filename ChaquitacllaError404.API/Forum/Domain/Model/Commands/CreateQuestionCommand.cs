namespace ChaquitacllaError404.API.Forum.Domain.Model.Commands;

public record CreateQuestionCommand(int AuthorId, int CategoryId, string QuestionText);