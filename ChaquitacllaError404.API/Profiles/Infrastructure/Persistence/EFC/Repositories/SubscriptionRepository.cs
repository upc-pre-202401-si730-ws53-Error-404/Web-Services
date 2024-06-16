using ChaquitacllaError404.API.Profiles.Domain.Model.Entities;
using ChaquitacllaError404.API.Profiles.Domain.Repositories;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ChaquitacllaError404.API.Profiles.Infrastructure.Persistence.EFC.Repositories;

public class SubscriptionRepository(AppDbContext context) : BaseRepository<Subscription>(context), ISubscriptionRepository
{
    
}