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
using ChaquitacllaError404.API.IAM.Application.Internal.CommandServices;
using ChaquitacllaError404.API.IAM.Application.Internal.OutboundServices;
using ChaquitacllaError404.API.IAM.Application.Internal.QueryServices;
using ChaquitacllaError404.API.IAM.Domain.Repositories;
using ChaquitacllaError404.API.IAM.Domain.Services;
using ChaquitacllaError404.API.IAM.Infrastructure.Hashing.BCrypt.Services;
using ChaquitacllaError404.API.IAM.Infrastructure.Persistence.EFC.Repositories;
using ChaquitacllaError404.API.IAM.Infrastructure.Pipeline.Middleware.Extensions;
using ChaquitacllaError404.API.IAM.Infrastructure.Tokens.JWT.Configuration;
using ChaquitacllaError404.API.IAM.Infrastructure.Tokens.JWT.Services;
using ChaquitacllaError404.API.IAM.Interfaces.ACL;
using ChaquitacllaError404.API.IAM.Interfaces.ACL.Services;
using ChaquitacllaError404.API.Profiles.Application.Internal.CommandServices;
using ChaquitacllaError404.API.Profiles.Application.Internal.QueryServices;
using ChaquitacllaError404.API.Profiles.Domain.Repositories;
using ChaquitacllaError404.API.Profiles.Domain.Services;
using ChaquitacllaError404.API.Profiles.Infrastructure.Persistence.EFC.Repositories;
using ChaquitacllaError404.API.Shared.Domain.Repositories;
using  ChaquitacllaError404.API.Shared.Interfaces.ASP.Configuration;
using  ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using  ChaquitacllaError404.API.Shared.Infrastructure.Persistence.EFC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.Conventions.Add(new KebabCaseRouteNamingConvention());
});


// Add Database Connection String
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Configure Database Context and Logging Level
builder.Services.AddDbContext<AppDbContext>(
    options =>
    {
        if (connectionString != null)
            if (builder.Environment.IsDevelopment())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Information)
                    .EnableSensitiveDataLogging()
                    .EnableDetailedErrors();
            else if (builder.Environment.IsProduction())
                options.UseMySQL(connectionString)
                    .LogTo(Console.WriteLine, LogLevel.Error)
                    .EnableDetailedErrors();    
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(
    c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "ChaquitacllaError404.API",
                Version = "v1",
                Description = "Chaquitaclla Error 404 Platform API",
                TermsOfService = new Uri("https://github.com/upc-pre-202401-si730-ws53-Error-404/Web-Services"),
                Contact = new OpenApiContact
                {
                    Name = "Error 404 development team",
                    Email = "u202124343@upc."
                },
                License = new OpenApiLicense
                {
                    Name = "Apache 2.0",
                    Url = new Uri("https://www.apache.org/licenses/LICENSE-2.0.html")
                }
            });
        c.EnableAnnotations();
        c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
        {
            In = ParameterLocation.Header,
            Description = "Please enter token",
            Name = "Authorization",
            Type = SecuritySchemeType.Http,
            BearerFormat = "JWT",
            Scheme = "bearer"
        });
        c.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Id = "Bearer",
                        Type = ReferenceType.SecurityScheme
                    }
                },
                Array.Empty<string>()
            } 
        });
    });


builder.Services.AddRouting(options => options.LowercaseUrls = true);

// Add CORS Policy
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowedAllPolicy",
        policy => policy
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
});

// Shared Bounded Context Dependency Injections
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

//Sowings Bounded Context Dependency Injections

builder.Services.AddScoped<ISowingRepository, SowingRepository>();
builder.Services.AddScoped<ISowingCommandService, SowingCommandService>();
builder.Services.AddScoped<ISowingQueryService, SowingQueryService>();

//Controls Bounded Context Dependency Injections

builder.Services.AddScoped<IControlRepository, ControlRepository>();
builder.Services.AddScoped<IControlCommandService, ControlCommandService>();
builder.Services.AddScoped<IControlQueryService, ControlQueryService>();

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


//Forum Bounded Context Dependency Injections
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryCommandService, CategoryCommandService>();
builder.Services.AddScoped<ICategoryQueryService, CategoryQueryService>();

builder.Services.AddScoped<IQuestionRepository, QuestionRepository>();
builder.Services.AddScoped<IQuestionCommandService, QuestionCommandService>();
builder.Services.AddScoped<IQuestionQueryService, QuestionQueryService>();

builder.Services.AddScoped<IAnswerRepository, AnswerRepository>();
builder.Services.AddScoped<IAnswerCommandService, AnswerCommandService>();
builder.Services.AddScoped<IAnswerQueryService, AnswerQueryService>();

// IAM Bounded Context Injection Configuration
builder.Services.Configure<TokenSettings>(builder.Configuration.GetSection("TokenSettings"));
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserCommandService, UserCommandService>();
builder.Services.AddScoped<IUserQueryService, UserQueryService>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IHashingService, HashingService>();
builder.Services.AddScoped<IIamContextFacade, IamContextFacade>();

builder.Services.AddScoped<IControlRepository, ControlRepository>();
builder.Services.AddScoped<IControlCommandService, ControlCommandService>();
builder.Services.AddScoped<IControlQueryService, ControlQueryService>();

// Profiles Bounded Context Dependency Injections
builder.Services.AddScoped<IProfileRepository, ProfileRepository>();
builder.Services.AddScoped<IProfileCommandService, ProfileCommandService>();
builder.Services.AddScoped<IProfileQueryService, ProfileQueryService>();
builder.Services.AddScoped<ISubscriptionCommandService, SubscriptionCommandService>();
builder.Services.AddScoped<ISubscriptionRepository, SubscriptionRepository>();

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

// Apply CORS Policy
app.UseCors("AllowedAllPolicy");

app.UseRequestAuthorization();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();