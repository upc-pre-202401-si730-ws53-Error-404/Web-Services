using ChaquitacllaError404.API.Profiles.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Profiles.Domain.Model.Querys;

namespace ChaquitacllaError404.API.Profiles.Domain.Services;

public interface IProfileQueryService
{
    Task<IEnumerable<Profile>> Handle(GetAllProfilesQuery query);
    Task<Profile?> Handle(GetProfileByEmailQuery query);
    Task<Profile?> Handle(GetProfileByIdQuery query);
}