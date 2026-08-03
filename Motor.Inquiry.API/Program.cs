using Microsoft.EntityFrameworkCore;
using Motor.Inquiry.Application.Interfaces;
using Motor.Inquiry.Application.Services;
using Motor.Inquiry.Infrastructure.Clients;
using Motor.Inquiry.Infrastructure.Data;
using Motor.Inquiry.Infrastructure.Services;


var builder = WebApplication.CreateBuilder(args);


builder.Services.AddScoped<IInquiryService , InquiryService >();
builder.Services.AddScoped<IInquiryHistoryWriter, InquiryHistoryWriter>();

builder.Services.AddDbContext<MotorDbContext>(options => options.UseSqlServer( builder.Configuration.GetConnectionString("DefaultConnection")  ));


builder.Services.AddHttpClient<IYaqeenHttpClient, YaqeenHttpClient>( client => { client.BaseAddress = new Uri(builder.Configuration["YaqeenApi:BaseUrl"]!);  });

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
