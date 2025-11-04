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

    public async Task<Pedidos?> Buscar(int pedidoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.pedidos
            .Include(e => e.PedidosDetalles)
                .ThenInclude(d => d.Componentes)
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.PedidoId == pedidoId);
    }
    public async Task<bool> Insertar(Pedidos pedidos)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.pedidos.Add(pedidos);

        return await contexto.SaveChangesAsync() > 0;
    }
   
    public async Task<bool> Modificar(Pedidos pedidos)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        var anterior = await contexto.pedidos
            .Include(e => e.PedidosDetalles)
            .FirstOrDefaultAsync(e => e.PedidoId == pedidos.PedidoId);

        return await contexto.SaveChangesAsync() > 0;
    }

    public async Task<bool> Eliminar(int pedidoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();

        var entrada = await contexto.pedidos
            .Include(e => e.PedidosDetalles)
            .FirstOrDefaultAsync(e => e.PedidoId == pedidoId);

        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<bool> Existe(int pedidoId)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.pedidos
            .AnyAsync(e => e.PedidoId == pedidoId);
    }
    public async Task<List<Componentes>> ListarComponentes()
    {
        using var contexto = DbFactory.CreateDbContext();
        return await contexto.Componentes.ToListAsync();
    }
}

