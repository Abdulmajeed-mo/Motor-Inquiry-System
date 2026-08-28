using Yaqeen.Domain.Entities;

namespace Yaqeen.Application.Interfaces.Services;

public interface IModelService
{
    Task<IReadOnlyList<Model>> GetAllAsync();
}