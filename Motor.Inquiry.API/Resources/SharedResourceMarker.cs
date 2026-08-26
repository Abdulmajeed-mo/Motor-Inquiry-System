using System.Globalization;

namespace Motor.Inquiry.API.Resources;

public class SharedResourceMarker
{
    public static readonly CultureInfo DefaultCulture = new("ar");

    public static readonly CultureInfo EnglishCulture = new("en");

    public static readonly CultureInfo[] SupportedCultures =
    {
        DefaultCulture,
        EnglishCulture
    };
}