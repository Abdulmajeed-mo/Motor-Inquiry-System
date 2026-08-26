using Yaqeen.API.Middleware;
using Yaqeen.API.Extensions;

var builder = WebApplication.CreateBuilder(args);


// Register Yaqeen application services and infrastructure dependencies.
builder.Services.AddYaqeenServices(builder.Configuration);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();



var app = builder.Build();

// Configure Yaqeen custom middleware.
app.UseYaqeenMiddleware();


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
