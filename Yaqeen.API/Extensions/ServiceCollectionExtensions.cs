using Microsoft.EntityFrameworkCore;
using Yaqeen.Application.Interfaces;
using Yaqeen.Application.Interfaces.Repositories;
using Yaqeen.Application.Interfaces.Services;
using Yaqeen.Application.Services;
using Yaqeen.Infrastructure.Data.Context;
using Yaqeen.Infrastructure.Repositories;

namespace Yaqeen.API.Extensions;

public static class ServiceCollectionExtensions
{
    // Extension methods for registering Yaqeen application and infrastructure services.

    public static IServiceCollection AddYaqeenServices(this IServiceCollection services,IConfiguration configuration)
    {


        // Registers Yaqeen services, repositories, and database context for dependency injection.
        services.AddSingleton<IMakeService, MakeService>();
        services.AddSingleton<IModelService, ModelService>();

        services.AddScoped<IMakeRepository, MakeRepository>();
        services.AddScoped<IModelRepository, ModelRepository>();

        services.AddDbContext<YaqeenDbContext>(options =>options.UseSqlServer(configuration.GetConnectionString("YaqeenConnection")));

        services.AddScoped<ICitizenService, CitizenService>();
        services.AddScoped<IVehicleService, VehicleService>();

        services.AddScoped<ICitizenRepository, CitizenRepository>();
        services.AddScoped<IVehicleRepository, VehicleRepository>();

        return services;
    }
}