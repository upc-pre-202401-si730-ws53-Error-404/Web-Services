using ChaquitacllaError404.API.Profiles.Domain.Model.ValueObjects;

namespace ChaquitacllaError404.API.Profiles.Domain.Model.Querys;

public record GetProfileByEmailQuery(EmailAddress Email);