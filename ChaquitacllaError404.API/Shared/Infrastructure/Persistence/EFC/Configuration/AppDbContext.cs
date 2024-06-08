using ChaquitacllaError404.API.Users.Domain.Model.Aggregates;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using Microsoft.EntityFrameworkCore;

namespace FlexPalPlatform.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
{
    base.OnModelCreating(builder);

    // Users Context
    builder.Entity<User>().ToTable("Users");
    builder.Entity<User>().HasKey(u => u.Id);
    builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
    builder.Entity<User>().Property(u => u.FirstName).IsRequired();
    builder.Entity<User>().Property(u => u.LastName).IsRequired();
    builder.Entity<User>().Property(u => u.Password).IsRequired();
    builder.Entity<User>().Property(u => u.Email).IsRequired();
    builder.Entity<User>().Property(u => u.Subscription).IsRequired();

    // Apply SnakeCase Naming Convention
    builder.UseSnakeCaseWithPluralizedTableNamingConvention();
}


}
