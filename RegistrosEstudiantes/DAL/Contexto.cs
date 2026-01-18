using RegistrosEstudiantes.Models;
using Microsoft.EntityFrameworkCore;

namespace RegistrosEstudiantes.DAL
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions options) : base(options) { }
        public DbSet<Estudiantes> Estudiantes { get; set; }

    }
}
