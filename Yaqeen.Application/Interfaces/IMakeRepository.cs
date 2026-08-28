using Yaqeen.Domain.Entities;

namespace Yaqeen.Application.Interfaces.Repositories;

public interface IMakeRepository
{
    Task<IReadOnlyList<Make>> GetAllAsync();
}