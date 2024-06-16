using ChaquitacllaError404.API.Profiles.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Profiles.Domain.Model.ValueObjects;
using ChaquitacllaError404.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.Profiles.Domain.Repositories;

public interface IProfileRepository : IBaseRepository<Profile>
{
    Task<Profile?> FindProfileByEmailAsync(EmailAddress email);
}