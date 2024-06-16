using ChaquitacllaError404.API.Profiles.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Profiles.Domain.Model.Commands;

namespace ChaquitacllaError404.API.Profiles.Domain.Services;

public interface IProfileCommandService
{
    Task<Profile?> Handle(CreateProfileCommand command);
}