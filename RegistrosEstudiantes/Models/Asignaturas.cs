using System.ComponentModel.DataAnnotations;

namespace RegistrosEstudiantes.Models
{
    public class Asignaturas
    {
        [Key]
        public int AsignaturasId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public int? Codigo { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Aula { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es requerido")]
        [Range(1,4,ErrorMessage ="Los creditos van en este rango de numeros")]
        public int? Creditos { get; set; }
    }
}
