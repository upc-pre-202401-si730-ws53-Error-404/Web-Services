using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace ChaquitacllaError404.API.Crops.Infrastructure.Persistence.EFC.Repositories;

public class ProductsBySowingRepository(AppDbContext context) :  BaseRepository<ProductsBySowing>(context), IProductsBySowingRepository
{
    
}