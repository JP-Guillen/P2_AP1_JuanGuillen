using Microsoft.EntityFrameworkCore;
using P2_AP1_JuanGuillen.DAL;
using P2_AP1_JuanGuillen.Models;
using System.Linq.Expressions;

namespace P2_AP1_JuanGuillen.Services;

public class RegistroServices(IDbContextFactory<Contexto> DbFactory)
{

    public async Task<List<Pedidos>> Listar(Expression<Func<Pedidos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.pedidos
            .Where(criterio)
            .AsNoTracking()
            .ToListAsync();
    }
}

