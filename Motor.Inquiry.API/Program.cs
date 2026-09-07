using Motor.Inquiry.API.Extensions;
using Serilog;
using Microsoft.AspNetCore.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
// Configures the application by registering services and building the HTTP request pipeline.


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddLocalization(options =>
{
    options.ResourcesPath = "Resources";
});



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
builder.Services.AddApiServices(builder.Configuration);

builder.Services.AddControllers();



// Configure the HTTP request pipeline.
var app = builder.Build();

var supportedCultures = new[]
{
    new CultureInfo("en"),
    new CultureInfo("ar")
};

var localizationOptions = new RequestLocalizationOptions
{
    DefaultRequestCulture = new RequestCulture("en"),
    SupportedCultures = supportedCultures,
    SupportedUICultures = supportedCultures
};



app.UseRequestLocalization(localizationOptions);



//HTTP Pipeline
// Configure the HTTP request pipeline
app.UseApplicationPipeline();

app.Run();