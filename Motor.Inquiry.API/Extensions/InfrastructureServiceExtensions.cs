using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Motor.Inquiry.Application.Interfaces;
using Motor.Inquiry.Infrastructure.Clients;
using Motor.Inquiry.Infrastructure.Configuration;
using Motor.Inquiry.Infrastructure.Data.Context;
using Motor.Inquiry.Infrastructure.Services;

namespace Motor.Inquiry.API.Extensions;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,IConfiguration configuration)
    {

        services.AddScoped<IInquiryHistoryWriter, InquiryHistoryWriter>();

        services.AddDbContext<MotorDbContext>(options =>options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


        //Typed HttpClient for Yaqeen API 
        services.AddHttpClient<IYaqeenHttpClient, YaqeenHttpClient>((serviceProvider, client) =>
            {
                var options = serviceProvider.GetRequiredService<IOptions<YaqeenApiOptions>>().Value;

                client.BaseAddress = new Uri(options.BaseUrl);
            })
            .AddStandardResilienceHandler();


        services.AddMemoryCache();


        services.AddHttpContextAccessor();

        return services;
    }
}