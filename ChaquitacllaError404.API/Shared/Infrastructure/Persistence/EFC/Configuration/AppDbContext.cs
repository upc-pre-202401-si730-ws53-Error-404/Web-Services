
using ChaquitacllaError404.API.Crops.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Forum.Domain.Model.Aggregates;
using ChaquitacllaError404.API.Forum.Domain.Model.Entities;
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
        
        //Forum
        builder.Entity<Question>().ToTable("Questions");
        builder.Entity<Question>().HasKey(q => q.Id);
        builder.Entity<Question>().Property(q => q.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Question>().Property(q => q.Category).IsRequired();
        builder.Entity<Question>().Property(q => q.Ask).IsRequired();
        
        builder.Entity<Answer>().ToTable("Answers");
        builder.Entity<Answer>().HasKey(a => a.Id);
        builder.Entity<Answer>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Answer>().Property(a => a.AnswerText).IsRequired();
        
        builder.Entity<Question>()
            .HasMany(q => q.Answers)
            .WithOne(a => a.Question)
            .HasForeignKey(a => a.QuestionId)
            .HasPrincipalKey(a => a.Id);
        
        
        builder.UseSnakeCaseNamingConvention();
    }
}