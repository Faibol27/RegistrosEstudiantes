using System.ComponentModel.DataAnnotations;
namespace RegistrosEstudiantes.Models
{
    public class Estudiantes
    {
        [Key]
        public int EstudiantesId { get; set; }

        [Required(ErrorMessage = "Estos campos son obligatorios")]
        public string NombreEstudiante { get; set; } = string.Empty;
        public string EmailEstudiantes { get; set; } = string.Empty;

    }
}
