using Microsoft.EntityFrameworkCore;
using Registro_Asignaturas.Models;
using RegistrosEstudiantes.DAL;
using RegistrosEstudiantes.Models;
using System.Linq.Expressions;

namespace RegistrosEstudiantes.Services
{
    public class AsignaturaServices(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Guardar(Asignaturas asignatura)
        {
            if (!await Existe(asignatura.Nombre, asignatura.AsignaturaId))
            {
                return await Insertar(asignatura);
            }
            else
            {
                return await Modificar(asignatura);
            }
        }
        public async Task<bool> Existe(string nombre, int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas.AnyAsync(e => e.Nombre.ToLower() == nombre.ToLower()
                    && e.AsignaturaId != id);
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
            return await contexto.Asignaturas.FirstOrDefaultAsync(e => e.AsignaturaId == id);
        }
        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas.Where(e => e.AsignaturaId == id).ExecuteDeleteAsync() > 0;
        }
        public async Task<List<Asignaturas>> Listar(Expression<Func<Asignaturas, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Asignaturas.Where(criterio).AsNoTracking().ToListAsync();
        }
    }
}
