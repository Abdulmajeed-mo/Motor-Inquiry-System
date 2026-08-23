

// for Application Configuration / Options


namespace Motor.Inquiry.Infrastructure.Configuration;

public class CacheSettingsOptions
{
    public const string SectionName = "CacheSettings";

    public int ExpirationMinutes { get; set; }
}