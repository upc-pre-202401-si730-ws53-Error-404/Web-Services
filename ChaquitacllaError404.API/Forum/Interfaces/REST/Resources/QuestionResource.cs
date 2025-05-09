namespace ChaquitacllaError404.API.Forum.Interfaces.REST.Resources;

public record QuestionResource(int QuestionId, int AuthorId, int CategoryId, string QuestionText, DateTime Date);