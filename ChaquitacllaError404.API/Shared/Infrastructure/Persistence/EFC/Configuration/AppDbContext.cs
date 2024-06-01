
using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
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
        
        // Sowing Aggregate
        builder.Entity<Sowing>().ToTable("Sowings");
        builder.Entity<Sowing>().HasKey(f=>f.Id);
        builder.Entity<Sowing>().Property(f=>f.Id).ValueGeneratedOnAdd();
        builder.Entity<Sowing>().Property(f=>f.AreaLand).IsRequired();
        builder.Entity<Sowing>().Property(f=>f.PhenologicalPhase).IsRequired();
        builder.Entity<Sowing>().Property(f=>f.CropId).IsRequired();
        
        builder.Entity<Sowing>()
            .HasOne(s => s.Crop)
            .WithMany(c => c.Sowings) 
            .HasForeignKey(s => s.CropId);
        // Crop Aggregate
        builder.Entity<Crop>().ToTable("Crops");
        builder.Entity<Crop>().HasKey(f => f.Id);
        builder.Entity<Crop>().Property(f=>f.Id).ValueGeneratedOnAdd();
        builder.Entity<Crop>().Property(f => f.Name).IsRequired();
        builder.Entity<Crop>().Property(f => f.Description).IsRequired();
        
        //Product Entity 
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Product>().HasKey(f => f.Id);
        builder.Entity<Product>().Property(f => f.Id).ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(f => f.Name).IsRequired();
        builder.Entity<Product>().Property(f => f.Type).IsRequired();
        
        //ProductsBySowing Entity
        builder.Entity<ProductsBySowing>().ToTable("ProductsBySowing");
        builder.Entity<ProductsBySowing>().HasKey(f => new {f.ProductId, f.SowingId});
        builder.Entity<ProductsBySowing>().Property(f => f.ProductId).IsRequired();
        builder.Entity<ProductsBySowing>().Property(f => f.SowingId).IsRequired();
        builder.Entity<ProductsBySowing>().Property(f => f.Quantity).IsRequired();
        builder.Entity<ProductsBySowing>().Property(f => f.UseDate).IsRequired();
        
        //Disease Entity
        builder.Entity<Disease>().ToTable("Diseases");
        builder.Entity<Disease>().HasKey(f => f.Id);
        builder.Entity<Disease>().Property(f => f.Id).ValueGeneratedOnAdd();
        builder.Entity<Disease>().Property(f => f.Name).IsRequired();
        builder.Entity<Disease>().Property(f => f.Description).IsRequired();
        
        
        //Relationships of many to many about Products and Sowings
        builder.Entity<ProductsBySowing>()
            .HasOne(p => p.Product)
            .WithMany(p => p.ProductsBySowing)
            .HasForeignKey(p => p.ProductId);
        
        builder.Entity<ProductsBySowing>()
            .HasOne(p => p.Sowing)
            .WithMany(s => s.ProductsBySowing)
            .HasForeignKey(p => p.SowingId);
        
        //Relationships of many to many about Crops and Diseases
        builder.Entity<Crop>()
            .HasMany(e => e.Diseases)
            .WithMany(e => e.Crops)
            .UsingEntity<CropsDiseases>();
        
        
        //Relationships of many to many about Crops and Pests
        builder.Entity<Crop>()
            .HasMany(e => e.Pests)
            .WithMany(e => e.Crops)
            .UsingEntity<CropsPests>();
        
        
        
        
        builder.UseSnakeCaseNamingConvention();
    }
}

