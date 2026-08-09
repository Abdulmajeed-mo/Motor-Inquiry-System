using Yaqeen.API.Middleware;
using Yaqeen.Application.Interfaces;
using Yaqeen.Application.Services;

var builder = WebApplication.CreateBuilder(args);

// Service Registration for Dependency Injectionما
builder.Services.AddScoped<ICitizenService, CitizenService>();
builder.Services.AddScoped<IVehicleService, VehicleService>();


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
