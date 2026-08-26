using Microsoft.EntityFrameworkCore;
using Yaqeen.API.Middleware;
using Yaqeen.Application.Interfaces;
using Yaqeen.Application.Services;
using Yaqeen.Infrastructure.Data.Context;
using Yaqeen.Infrastructure.Repositories;
using Yaqeen.Application.Interfaces;
using Yaqeen.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<YaqeenDbContext>(options =>options.UseSqlServer(builder.Configuration.GetConnectionString("YaqeenConnection")));

// Service Registration for Dependency Injection
builder.Services.AddScoped<ICitizenService, CitizenService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();


builder.Services.AddScoped<ICitizenRepository, CitizenRepository>();
builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseMiddleware<CorrelationIdMiddleware>();
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
