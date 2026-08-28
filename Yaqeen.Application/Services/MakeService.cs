using Yaqeen.Application.Interfaces;
using Yaqeen.Application.Interfaces.Repositories;
using Yaqeen.Application.Interfaces.Services;
using Yaqeen.Domain.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Yaqeen.Application.Services;

public class MakeService : IMakeService
{
    private readonly IServiceScopeFactory _scopeFactory;

    public MakeService(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    public async Task<IReadOnlyList<Make>> GetAllAsync()
    {
        using var scope = _scopeFactory.CreateScope();

        var repository = scope.ServiceProvider
            .GetRequiredService<IMakeRepository>();

        return await repository.GetAllAsync();
    }
}