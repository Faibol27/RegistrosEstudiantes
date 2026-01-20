using System.ComponentModel.DataAnnotations;
namespace RegistrosEstudiantes.Models;
    public class Estudiantes
    {
        [Key]
        public int EstudiantesId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string NombreEstudiante { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es requerido")]
        [EmailAddress(ErrorMessage = "EL formato del correo no es valido")]
        public string EmailEstudiantes { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es requerido")]
        [Range (1,100,ErrorMessage = "La edad debe de estar en este rango 1-100")]
        public int? EdadEstudiantes{ get; set; } 

    }

