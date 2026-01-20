using RegistrosEstudiantes.Models;
using Microsoft.EntityFrameworkCore;
using Registro_Asignaturas.Models;

namespace RegistrosEstudiantes.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base(options) { }
        public DbSet<Estudiantes> Estudiantes { get; set; }
        public DbSet<Asignaturas> Asignaturas { get; set; }
    }
}
