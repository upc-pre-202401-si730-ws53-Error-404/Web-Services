namespace ChaquitacllaError404.API.Forum.Interfaces.REST.Resources;

public record AnswerResource(int AnswerId, int AuthorId, int QuestionId, string AnswerText);