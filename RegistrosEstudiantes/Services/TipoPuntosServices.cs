using Microsoft.EntityFrameworkCore;
using Registro_Asignaturas.Models;
using RegistrosEstudiantes.DAL;
using RegistrosEstudiantes.Models;
using System.Linq.Expressions;

namespace RegistrosEstudiantes.Services;

public class TipoPuntosServices(IDbContextFactory<Contexto> DbFactory)
{
    public async Task<bool> Guardar(TipoPuntos tipoPuntos)
    {
        if (!await Existe(tipoPuntos.Nombre, tipoPuntos.TipoId))
        {
            return await Insertar(tipoPuntos);
        }
        else
        {
            return await Modificar(tipoPuntos);
        }
    }
    public async Task<bool> Existe(string nombre, int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TipoPuntos.AnyAsync(e => e.Nombre.ToLower() == nombre.ToLower()
                && e.TipoId != id);
    }
    private async Task<bool> Insertar(TipoPuntos tipoPuntos)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.TipoPuntos.Add(tipoPuntos);
        return await contexto.SaveChangesAsync() > 0;
    }
    private async Task<bool> Modificar(TipoPuntos tipoPuntos)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        contexto.TipoPuntos.Update(tipoPuntos);
        return await contexto.SaveChangesAsync() > 0;
    }
    public async Task<TipoPuntos?> Buscar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TipoPuntos.FirstOrDefaultAsync(e => e.TipoId == id);
    }
    public async Task<bool> Eliminar(int id)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TipoPuntos.Where(e => e.TipoId == id).ExecuteDeleteAsync() > 0;
    }
    public async Task<List<TipoPuntos>> Listar(Expression<Func<TipoPuntos, bool>> criterio)
    {
        await using var contexto = await DbFactory.CreateDbContextAsync();
        return await contexto.TipoPuntos.Where(criterio).AsNoTracking().ToListAsync();
    }
}
