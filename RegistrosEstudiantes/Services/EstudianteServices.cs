using Microsoft.EntityFrameworkCore;
using RegistrosEstudiantes.DAL;
using RegistrosEstudiantes.Models;
using System.Linq.Expressions;

namespace RegistrosEstudiantes.Services
{
    public class EstudianteServices(IDbContextFactory<Contexto> DbFactory)
    {
        public async Task<bool> Guardar(Estudiantes estudiante)
        {
            if (!await Existe(estudiante.NombreEstudiante,estudiante.EstudiantesId))
            {
                return await Insertar(estudiante);
            }
            else
            {
                return await Modificar(estudiante);
            }
        }
        public async Task<bool> Existe(string nombreEstudiante, int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Estudiantes.AnyAsync(e => e.NombreEstudiante.ToLower() == nombreEstudiante.ToLower()
                    && e.EstudiantesId != id);
        }
        private async Task<bool> Insertar(Estudiantes estudiante)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Estudiantes.Add(estudiante);
            return await contexto.SaveChangesAsync() > 0;
        }
        private async Task<bool> Modificar(Estudiantes estudiante)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            contexto.Estudiantes.Update(estudiante);
            return await contexto.SaveChangesAsync() > 0;
        }
        public async Task<Estudiantes?> Buscar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Estudiantes.FirstOrDefaultAsync(e => e.EstudiantesId == id);
        }
        public async Task<bool> Eliminar(int id)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Estudiantes.Where(e => e.EstudiantesId == id).ExecuteDeleteAsync() > 0;
        }
        public async Task<List<Estudiantes>> Listar(Expression<Func<Estudiantes, bool>> criterio)
        {
            await using var contexto = await DbFactory.CreateDbContextAsync();
            return await contexto.Estudiantes.Where(criterio).AsNoTracking().ToListAsync();
        }
    }
}
