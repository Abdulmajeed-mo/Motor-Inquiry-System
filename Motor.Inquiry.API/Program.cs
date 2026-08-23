using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Motor.Inquiry.API.Middleware;
using Motor.Inquiry.Application.Interfaces;
using Motor.Inquiry.Application.Mapping;
using Motor.Inquiry.Application.Services;
using Motor.Inquiry.Application.Validators;
using Motor.Inquiry.Infrastructure.Clients;
using Motor.Inquiry.Infrastructure.Data.Context;
using Motor.Inquiry.Infrastructure.Services;
using Serilog;
using System.Threading.RateLimiting;
using Microsoft.Extensions.Options;
using Motor.Inquiry.API.Configuration;
using Motor.Inquiry.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

builder.Services.Configure<YaqeenApiOptions>( builder.Configuration.GetSection(YaqeenApiOptions.SectionName));

builder.Services.Configure<CacheSettingsOptions>( builder.Configuration.GetSection(CacheSettingsOptions.SectionName));


//RateLimitOptions
builder.Services.Configure<RateLimitOptions>(builder.Configuration.GetSection(RateLimitOptions.SectionName));


builder.Host.UseSerilog((context, configuration) =>configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddScoped<IInquiryService , InquiryService >();

builder.Services.AddScoped<IInquiryHistoryWriter, InquiryHistoryWriter>();

builder.Services.AddDbContext<MotorDbContext>(options => options.UseSqlServer( builder.Configuration.GetConnectionString("DefaultConnection")  ));

//Typed HttpClient for Yaqeen API 
builder.Services.AddHttpClient<IYaqeenHttpClient, YaqeenHttpClient>(
(serviceProvider, client) =>
    {
        var options = serviceProvider.GetRequiredService<IOptions<YaqeenApiOptions>>().Value;
        client.BaseAddress = new Uri(options.BaseUrl);
    
    }).AddStandardResilienceHandler();


builder.Services.AddMemoryCache();

builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();


builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAutoMapper(cfg =>{  cfg.AddProfile<InquiryMappingProfile>();   });


//ليس معناها أننا نسجل الـ Sequence Validator فقط.
//كنقطة مرجعية للـ Assembly
builder.Services.AddValidatorsFromAssemblyContaining<InquiryBySequenceRequestValidator>();


//Rate Limiting Configuration
var rateLimitOptions = builder.Configuration
    .GetSection(RateLimitOptions.SectionName)
    .Get<RateLimitOptions>()!;


builder.Services.AddRateLimiter(options =>{options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>( httpContext => RateLimitPartition.GetFixedWindowLimiter(
    partitionKey: httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown",
    factory: _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = rateLimitOptions.PermitLimit, 
                Window = TimeSpan.FromMinutes(rateLimitOptions.WindowMinutes),
                QueueLimit = rateLimitOptions.QueueLimit
            }));

    options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;
});



builder.Services.AddHealthChecks();

builder.Services.AddApiVersioning();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure the HTTP request pipeline.

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

app.UseRateLimiter();

app.UseMiddleware<CorrelationIdMiddleware>();


if (app.Environment.IsDevelopment() || app.Environment.IsStaging())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapHealthChecks("/health");

app.Run();

