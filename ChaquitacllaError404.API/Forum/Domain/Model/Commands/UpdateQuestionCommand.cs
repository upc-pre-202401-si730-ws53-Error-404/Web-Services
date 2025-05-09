namespace ChaquitacllaError404.API.Forum.Domain.Model.Commands;

public record UpdateQuestionCommand(int QuestionId, int CategoryId, string QuestionText);