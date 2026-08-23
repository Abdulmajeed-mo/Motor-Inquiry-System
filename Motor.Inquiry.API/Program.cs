using Motor.Inquiry.API.Extensions;
using Serilog;


var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

//Configuration
// Register strongly typed application and infrastructure configuration
builder.Services.AddConfigurationServices(builder.Configuration);

builder.Host.UseSerilog((context, configuration) =>configuration.ReadFrom.Configuration(context.Configuration));

//Infrastructure Services
// Register infrastructure layer services, database, HTTP clients, and caching
builder.Services.AddInfrastructureServices(builder.Configuration);


// Register application layer services, validators, AutoMapper, and FluentValidation
builder.Services.AddApplicationServices();

//Rate Limiting
// Register rate limiting configuration
builder.Services.AddRateLimiting(builder.Configuration);

//API Services
// Register API services such as controllers, health checks, versioning, and Swagger
builder.Services.AddApiServices();


// Configure the HTTP request pipeline.
var app = builder.Build();

//HTTP Pipeline
// Configure the HTTP request pipeline
app.UseApplicationPipeline();

app.Run();