using ChaquitacllaError404.API.Crops.Application.CommandServices;
using  ChaquitacllaError404.API.Crops.Application.QueryServices;
using  ChaquitacllaError404.API.Crops.Domain.Repositories;
using  ChaquitacllaError404.API.Crops.Domain.Services;
using  ChaquitacllaError404.API.Crops.Infrastructure.Persistence.EFC.Repositories;
using ChaquitacllaError404.API.Forum.Application.CommandServices;
using ChaquitacllaError404.API.Forum.Application.QueryService;
using ChaquitacllaError404.API.Forum.Domain.Repositories;
using ChaquitacllaError404.API.Forum.Domain.Services;
using ChaquitacllaError404.API.Forum.Infrastructure.Persistence.EFC.Repositories;
using ChaquitacllaError404.API.Shared.Domain.Repositories;
using  ChaquitacllaError404.API.Shared.Infrastructure.Interfaces.ASP.Configuration;
using  ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using  ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using ChaquitacllaError404.API.Users.Application.Internal.CommandServices;
using ChaquitacllaError404.API.Users.Application.Internal.QueryServices;
using ChaquitacllaError404.API.Users.Domain.Repositories;
using ChaquitacllaError404.API.Users.Domain.Services;
using ChaquitacllaError404.API.Users.Infrastructure.Persistence.EFC.Repositories;
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

//Sowings Bounded Context Dependency Injections

builder.Services.AddScoped<ISowingRepository, SowingRepository>();
builder.Services.AddScoped<ISowingCommandService, SowingCommandService>();
builder.Services.AddScoped<ISowingQueryService, SowingQueryService>();

//Crops Bounded Context Dependency Injections

builder.Services.AddScoped<ICropRepository, CropRepository>();
builder.Services.AddScoped<ICropCommandService, CropCommandService>();
builder.Services.AddScoped<ICropQueryService, CropQueryService>();

builder.Services.AddScoped<IDiseaseRepository, DiseaseRepository>();
builder.Services.AddScoped<IDiseaseCommandService, DiseaseCommandService>();
builder.Services.AddScoped<IDiseaseQueryService, DiseaseQueryService>();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductCommandService, ProductCommandService>();
builder.Services.AddScoped<IProductQueryService, ProductQueryService>();

builder.Services.AddScoped<IPestRepository, PestRepository>();
builder.Services.AddScoped<IPestCommandService, PestCommandService>();
builder.Services.AddScoped<IPestQueryService, PestQueryService>();

//Users Bounded Context Dependency Injections

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();



//Forum Bounded Context Dependency Injections
builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuestionCommandService, QuestionCommandService>();
builder.Services.AddScoped<IQuestionQueryService, QuestionQueryService>();

builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IAnswerCommandService, AnswerCommandService>();
builder.Services.AddScoped<IAnswerQueryService, AnswerQueryService>();


var app = builder.Build();

// Verify Database Objects are created
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<AppDbContext>();
    context.Database.EnsureCreated();
}


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