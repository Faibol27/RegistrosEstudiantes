using Microsoft.EntityFrameworkCore;
using RegistrosEstudiantes.DAL;
using RegistrosEstudiantes.Models;
using System.Linq.Expressions;

namespace RegistrosEstudiantes.Services
{
    public class AsignaturaServices(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Guardar(Asignaturas asignatura)
        {
            if (!await Existe(asignatura.Nombre, asignatura.AsignaturasId))
            {
                return await Insertar(asignatura);
            }
            else
            {
                return await Modificar(asignatura);
            }
        }
        public async Task<bool> Existe(string nombreAsignatura, int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas.AnyAsync(e => e.Nombre.ToLower() == nombreAsignatura.ToLower()
                    && e.AsignaturasId != id);
        }
        private async Task<bool> Insertar(Asignaturas asignatura)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Asignaturas.Add(asignatura);
            return await contexto.SaveChangesAsync() > 0;
        }
        private async Task<bool> Modificar(Asignaturas asignatura)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Asignaturas.Update(asignatura);
            return await contexto.SaveChangesAsync() > 0;
        }
        public async Task<Asignaturas?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas.FirstOrDefaultAsync(e => e.AsignaturasId == id);
        }
        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas.Where(e => e.AsignaturasId == id).ExecuteDeleteAsync() > 0;
        }
        public async Task<List<Asignaturas>> Listar(Expression<Func<Asignaturas, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas.Where(criterio).AsNoTracking().ToListAsync();
        }
    }
}
