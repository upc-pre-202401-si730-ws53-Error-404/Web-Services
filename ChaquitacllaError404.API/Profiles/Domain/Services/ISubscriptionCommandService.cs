using ChaquitacllaError404.API.Profiles.Domain.Model.Commands;
using ChaquitacllaError404.API.Profiles.Domain.Model.Entities;

namespace ChaquitacllaError404.API.Profiles.Domain.Services;

public interface ISubscriptionCommandService
{
    Task<Subscription?> Handle(CreateSubscriptionCommand command);
}