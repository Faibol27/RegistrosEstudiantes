using Blazored.Toast.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace RegistrosEstudiantes.Models
{
    public class TipoPuntos
    {
        [Key]
        public int TipoId { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Nombre { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es requerido")]
        public string Descripcion { get; set; } = string.Empty;

        [Required(ErrorMessage = "Este campo es requerido")]
        public int ValorPuntos { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public Color Color { get; set; }

        [Required(ErrorMessage = "Este campo es requerido")]
        public IconType Icon { get; set; } 

        [Required(ErrorMessage = "Este campo es requerido")]
        public bool Estado { get; set; } = false; 
    }
}
