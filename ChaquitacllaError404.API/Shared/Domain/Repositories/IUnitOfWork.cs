namespace ChaquitacllaError404.API.Shared.Domain.Repositories;

public interface IUnitOfWork
{
    Task CompleteAsync();
}