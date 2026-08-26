namespace Motor.Inquiry.Domain.Entities;


//بنستخدمه لمعرفة هل مرّ شهر على البيانات أم لا.
public class VehicleInquiryCache
{
    public int Id { get; set; }

    public string CacheKey { get; set; } = string.Empty;

    public string? NationalId { get; set; }

    public int? SequenceNumber { get; set; }

    public string? PlateNumber { get; set; }

    public string? PlateLetters { get; set; }

    public string Make { get; set; } = string.Empty;

    public string Model { get; set; } = string.Empty;

    public int ModelYear { get; set; }

    public string Color { get; set; } = string.Empty;

    public string ChassisNumber { get; set; } = string.Empty;

    public string OwnerNationalId { get; set; } = string.Empty;

    public DateTime CachedAt { get; set; }
}