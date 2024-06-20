
using ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Forum.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Forum.Domain.Model.Entities;
using ChaquitacllaError404.API.Crops.Domain.Model.Entities;
using ChaquitacllaError404.API.IAM.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Profiles.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Profiles.Domain.Model.Entities;
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
        
  
    //Forum
        builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Name).IsRequired();
    
        builder.Entity<Question>().HasKey(q => q.Id);
        builder.Entity<Question>().Property(q => q.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Question>().Property(q => q.QuestionText).IsRequired();
        
        builder.Entity<Category>()
            .HasMany(c => c.Questions)
            .WithOne(q => q.Category)
            .HasForeignKey(q => q.CategoryId);
            
        builder.Entity<Answer>().HasKey(a => a.Id);
        builder.Entity<Answer>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Answer>().Property(a => a.AnswerText).IsRequired();



        builder.Entity<Question>()
            .HasMany(q => q.Answers)
            .WithOne(a => a.Question)
            .HasForeignKey(a => a.QuestionId);

        // Sowing Aggregate
        builder.Entity<Sowing>().HasKey(f=>f.Id);
        builder.Entity<Sowing>().Property(f=>f.Id).ValueGeneratedOnAdd();
        builder.Entity<Sowing>().Property(f=>f.AreaLand).IsRequired();


        builder.Entity<Sowing>().Property(f=>f.PhenologicalPhase).IsRequired();
        builder.Entity<Sowing>().Property(f=>f.CropId).IsRequired();
        
        builder.Entity<Sowing>()
            .HasOne(s => s.Crop)
            .WithMany(c => c.Sowings) 
            .HasForeignKey(s => s.CropId);
        
        // Control Aggregate
        
        builder.Entity<Control>().HasKey(f => f.Id);
        builder.Entity<Control>().Property(f => f.Id).ValueGeneratedOnAdd();
        builder.Entity<Control>().Property(f => f.SowingCondition).IsRequired();
        builder.Entity<Control>().Property(f => f.SoilMoisture).IsRequired();
        builder.Entity<Control>().Property(f => f.StemCondition).IsRequired();
        builder.Entity<Control>().Property(f => f.SowingId).IsRequired();
      
        // Crop Aggregate
        builder.Entity<Crop>().HasKey(f => f.Id);
        builder.Entity<Crop>().Property(f=>f.Id).ValueGeneratedOnAdd();
        builder.Entity<Crop>().Property(f => f.Name).IsRequired();
        builder.Entity<Crop>().Property(f => f.Description).IsRequired();
        
        //Product Entity 
        builder.Entity<Product>().HasKey(f => f.Id);
        builder.Entity<Product>().Property(f => f.Id).ValueGeneratedOnAdd();
        builder.Entity<Product>().Property(f => f.Name).IsRequired();
        builder.Entity<Product>().Property(f => f.Type).IsRequired();
        
        //ProductsBySowing Entity
        builder.Entity<ProductsBySowing>().HasKey(f => new {f.ProductId, f.SowingId});
        builder.Entity<ProductsBySowing>().Property(f => f.ProductId).IsRequired();
        builder.Entity<ProductsBySowing>().Property(f => f.SowingId).IsRequired();
        builder.Entity<ProductsBySowing>().Property(f => f.Quantity).IsRequired();
        builder.Entity<ProductsBySowing>().Property(f => f.UseDate).IsRequired();
        
        //Disease Entity
        builder.Entity<Disease>().HasKey(f => f.Id);
        builder.Entity<Disease>().Property(f => f.Id).ValueGeneratedOnAdd();
        builder.Entity<Disease>().Property(f => f.Name).IsRequired();
        builder.Entity<Disease>().Property(f => f.Description).IsRequired();
        
        //Pest Entity
        builder.Entity<Pest>().HasKey(f => f.Id);
        builder.Entity<Pest>().Property(f => f.Id).ValueGeneratedOnAdd();
        builder.Entity<Pest>().Property(f => f.Name).IsRequired();
        builder.Entity<Pest>().Property(f => f.Description).IsRequired();
        
        // CropsDiseases Entity
        builder.Entity<CropsDiseases>().HasKey(cd => new { cd.CropId, cd.DiseaseId });
        builder.Entity<CropsDiseases>().Property(cd => cd.CropId).IsRequired();
        builder.Entity<CropsDiseases>().Property(cd => cd.DiseaseId).IsRequired();
        
        // CropsPests Entity
        builder.Entity<CropsPests>().HasKey(cp => new { cp.CropId, cp.PestId });
        builder.Entity<CropsPests>().Property(cp => cp.CropId).IsRequired();
        builder.Entity<CropsPests>().Property(cp => cp.PestId).IsRequired();
        
        // Control Entity
        builder.Entity<Control>().HasKey(f => f.Id);
        builder.Entity<Control>().Property(f => f.Id).ValueGeneratedOnAdd();
        builder.Entity<Control>().Property(f => f.SowingId).IsRequired();
        builder.Entity<Control>().Property(f => f.SowingCondition).IsRequired();
        builder.Entity<Control>().Property(f => f.SoilMoisture).IsRequired();
        builder.Entity<Control>().Property(f => f.StemCondition).IsRequired();
        
        // Add a navigation property for Controls
        builder.Entity<Sowing>()
            .HasMany(s => s.Controls)
            .WithOne(c => c.Sowing)
            .HasForeignKey(c => c.SowingId);
        
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
            .HasMany(e => e.CropDiseases)
            .WithOne(e => e.Crop)
            .HasForeignKey(e => e.CropId);

        builder.Entity<Disease>()
            .HasMany(e => e.CropsDiseases)
            .WithOne(e => e.Disease)
            .HasForeignKey(e => e.DiseaseId);
        
        //Relationships of many to many about Crops and Pests
        builder.Entity<Crop>()
            .HasMany(e => e.CropPests)
            .WithOne(e => e.Crop)
            .HasForeignKey(e => e.CropId);
        
        builder.Entity<Pest>()
            .HasMany(e => e.CropsPests)
            .WithOne(e => e.Pest)
            .HasForeignKey(e => e.PestId);
        
        
        // IAM Context
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        
        // Profiles Context
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.FirstName).HasColumnName("FirstName");
                n.Property(p => p.LastName).HasColumnName("LastName");
            });
        builder.Entity<Profile>().Property(p => p.CountryId).IsRequired();
        builder.Entity<Profile>().Property(p => p.CityId);
        builder.Entity<Profile>().OwnsOne(p => p.Email,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.Address).HasColumnName("EmailAddress");
            });
        builder.Entity<Profile>().Property(p => p.SubscriptionId).IsRequired();
        builder.Entity<Subscription>().Property(p=>p.Description).IsRequired();
        builder.Entity<Subscription>().Property(p=>p.Price).IsRequired();
        builder.Entity<Subscription>().Property(p=>p.Range).IsRequired();
        
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();
    }
}
        
      
        