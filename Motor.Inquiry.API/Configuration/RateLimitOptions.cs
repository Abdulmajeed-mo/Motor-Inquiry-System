
//For API rate limiting configuration options

namespace Motor.Inquiry.API.Configuration;

public class RateLimitOptions
{
    public const string SectionName = "RateLimit";

    public int PermitLimit { get; set; }
    public int WindowMinutes { get; set; }
    public int QueueLimit { get; set; }
}