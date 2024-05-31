using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Model.Queries;
using ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Crops.Domain.Services;

namespace ChaquitacllaError404.API.Crops.Application.QueryServices;

public class ProductQueryService(IProductRepository productRepository ): IProductQueryService
{
    public async Task<IEnumerable<Product>> Handle(GetAllProductsQuery query)
    {
        return await productRepository.ListAsync();

    }

    public async Task<IEnumerable<Product>> Handle(GetProductsByTypeQuery query)
    {
        return await productRepository.FindByTypeAsync(query.Type);
    }

    public async Task<Product?> Handle(GetProductByIdQuery query)
    {
        return await productRepository.FindByIdAsync(query.ProductId);
    }
}