using ChaquitacllaError404.API.Crops.Application.CommandServices;
using  ChaquitacllaError404.API.Crops.Application.QueryServices;
using  ChaquitacllaError404.API.Crops.Domain.Repositories;
using  ChaquitacllaError404.API.Crops.Domain.Services;
using  ChaquitacllaError404.API.Crops.Infrastructure.Persistence.EFC.Repositories;
using  ChaquitacllaError404.API.Crops.Domain.Repositories;
using ChaquitacllaError404.API.Shared.Domain.Repositories;
using  ChaquitacllaError404.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using  ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using  ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add Database Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Level
builder.Services.AddDbContext<AppDbContext>(options =>
{
    if (connectionString != null)
        if (builder.Environment.IsDevelopment())
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
        else if (builder.Environment.IsProduction())
            options.UseMySQL(connectionString)
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors();
});

builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Configure Dependency Injections

// Shared Bounded Context Dependency Injections
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Crops Bounded Context Dependency Injections
builder.Services.AddScoped<ISowingRepository, SowingRepository>();
builder.Services.AddScoped<ISowingCommandService, SowingCommandService>();
builder.Services.AddScoped<ISowingQueryService, SowingQueryService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();