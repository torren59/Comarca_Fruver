using System.ComponentModel.DataAnnotations;

namespace Comarca_Fruver.ModelsDto
{
    public class UsuarioDto
    {
        public int UsuarioID { get; set; }
        [Required(ErrorMessage = "El documento es un campo obligatorio")]
        public int Documento { get; set; }
        [Required(ErrorMessage = "El Nombre es un campo obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Apellido es un campo obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El Celular es un campo obligatorio")]
        public int Celular { get; set; }
        [Required(ErrorMessage = "El Rol es un campo obligatorio")]
        public string Rol { get; set; }
        [Required(ErrorMessage = "La clave es un campo obligatorio")]
        public string Clave { get; set; }
    }
}
