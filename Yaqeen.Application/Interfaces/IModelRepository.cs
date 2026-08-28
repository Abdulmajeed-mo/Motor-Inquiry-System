using Yaqeen.Domain.Entities;

namespace Yaqeen.Application.Interfaces.Repositories;

public interface IModelRepository
{
    Task<IReadOnlyList<Model>> GetAllAsync();
}