using Yaqeen.Domain.Entities;

namespace Yaqeen.Application.Interfaces.Services;

public interface IMakeService
{
    Task<IReadOnlyList<Make>> GetAllAsync();
}