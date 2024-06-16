using ChaquitacllaError404.API.Profiles.Domain.Model.Commands;
using ChaquitacllaError404.API.Profiles.Domain.Model.Entities;
using ChaquitacllaError404.API.Profiles.Domain.Repositories;
using ChaquitacllaError404.API.Profiles.Domain.Services;
using ChaquitacllaError404.API.Shared.Domain.Repositories;

namespace ChaquitacllaError404.API.Profiles.Application.Internal.CommandServices;

public class SubscriptionCommandServiceService(ISubscriptionRepository subscriptionRepository, IUnitOfWork unitOfWork) : ISubscriptionCommandService
{
    public async Task<Subscription?> Handle(CreateSubscriptionCommand command)
    {
        var subscription = new Subscription(command);
        try
        {
            await subscriptionRepository.AddAsync(subscription);
            await unitOfWork.CompleteAsync();
            return subscription;
        } catch (Exception e)
        {
            Console.WriteLine($"An error occurred while creating the profile: {e.Message}");
            return null;
        }
    }
}