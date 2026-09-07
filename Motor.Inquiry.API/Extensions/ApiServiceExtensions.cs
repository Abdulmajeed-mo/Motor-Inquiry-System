using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Motor.Inquiry.API.Extensions;

public static class ApiServiceExtensions
{

    // Registers API services such as controllers, health checks, API versioning,  AddAuthorization & AddAuthentication , and Swagger.
    public static IServiceCollection AddApiServices(this IServiceCollection services , IConfiguration configuration)
    {

        // Add localization services
        services.AddLocalization(options =>{options.ResourcesPath = "Resources";});

        
        services.AddHealthChecks();

        services.AddApiVersioning();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>{options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!))
                };
            });


        services.AddAuthorization();

        services.AddEndpointsApiExplorer();

        services.AddSwaggerGen();



        return services;
    }
}
