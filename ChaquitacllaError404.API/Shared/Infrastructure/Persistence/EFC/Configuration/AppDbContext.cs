
using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        builder.Entity<Sowing>().ToTable("Sowings");
        builder.Entity<Sowing>().HasKey(f=>f.Id);
        builder.Entity<Sowing>().Property(f=>f.Id).ValueGeneratedOnAdd();
        builder.Entity<Sowing>().Property(f=>f.StartDate).IsRequired();
        builder.Entity<Sowing>().Property(f=>f.EndDate).IsRequired();
        builder.Entity<Sowing>().Property(f=>f.AreaLand).IsRequired();

        builder.UseSnakeCaseNamingConvention();
    }
}