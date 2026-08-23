using System.Threading.RateLimiting;
using Motor.Inquiry.API.Configuration;

namespace Motor.Inquiry.API.Extensions;

public static class RateLimitExtensions
{
    public static IServiceCollection AddRateLimiting(this IServiceCollection services,IConfiguration configuration)
    {
        var rateLimitOptions = configuration.GetSection(RateLimitOptions.SectionName).Get<RateLimitOptions>()!;

        services.AddRateLimiter(options =>
        {
            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>RateLimitPartition.GetFixedWindowLimiter(partitionKey: httpContext.Connection.RemoteIpAddress?.ToString()?? "unknown",factory: _ => new FixedWindowRateLimiterOptions
                            {
                                PermitLimit = rateLimitOptions.PermitLimit,
                                Window = TimeSpan.FromMinutes(rateLimitOptions.WindowMinutes),
                                QueueLimit = rateLimitOptions.QueueLimit
                            }));

            options.RejectionStatusCode =StatusCodes.Status429TooManyRequests;
        });

        return services;
    }
}