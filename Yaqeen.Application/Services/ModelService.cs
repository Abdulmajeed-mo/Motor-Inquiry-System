using Yaqeen.Application.Interfaces;
using Yaqeen.Application.Interfaces.Repositories;
using Yaqeen.Application.Interfaces.Services;
using Yaqeen.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;
namespace Yaqeen.Application.Services;

public class ModelService : IModelService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public ModelService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<IReadOnlyList<Model>> GetAllAsync()
    {
        using var scope = _scopeFactory.CreateScope();

        var repository = scope.ServiceProvider
            .GetRequiredService<IModelRepository>();

        return await repository.GetAllAsync();
    }
}