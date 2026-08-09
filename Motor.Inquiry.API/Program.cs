using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Motor.Inquiry.API.Middleware;
using Motor.Inquiry.Application.Interfaces;
using Motor.Inquiry.Application.Services;
using Motor.Inquiry.Application.Validators;
using Motor.Inquiry.Infrastructure.Clients;
using Motor.Inquiry.Infrastructure.Data;
using Motor.Inquiry.Infrastructure.Services;
using Serilog;
using Motor.Inquiry.Application.Mapping;



var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog((context, configuration) =>configuration.ReadFrom.Configuration(context.Configuration));

builder.Services.AddScoped<IInquiryService , InquiryService >();

builder.Services.AddScoped<IInquiryHistoryWriter, InquiryHistoryWriter>();

builder.Services.AddDbContext<MotorDbContext>(options => options.UseSqlServer( builder.Configuration.GetConnectionString("DefaultConnection")  ));


builder.Services.AddHttpClient<IYaqeenHttpClient, YaqeenHttpClient>( client => { client.BaseAddress = new Uri(builder.Configuration["YaqeenApi:BaseUrl"]!);  }) .AddStandardResilienceHandler();

builder.Services.AddMemoryCache();
builder.Services.AddHttpContextAccessor();

builder.Services.AddControllers();


builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddAutoMapper(cfg =>{  cfg.AddProfile<InquiryMappingProfile>();   });


//ليس معناها أننا نسجل الـ Sequence Validator فقط.
//كنقطة مرجعية للـ Assembly
builder.Services.AddValidatorsFromAssemblyContaining<InquiryBySequenceRequestValidator>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// Configure the HTTP request pipeline.

var app = builder.Build();
app.UseMiddleware<CorrelationIdMiddleware>();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
