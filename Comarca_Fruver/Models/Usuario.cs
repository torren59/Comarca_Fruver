using System.ComponentModel.DataAnnotations;

namespace Comarca_Fruver.Models
{
    public class Usuario
    {
        [Key]
        public int UsuarioID { get; set; }
        [Required(ErrorMessage ="El documento es un campo obligatorio")]
        public int Documento { get; set; }
        [Required(ErrorMessage = "El nombre es un campo obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El apellido es un campo obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El número celular es un campo obligatorio")]
        public int Celular { get; set; }
        [Required(ErrorMessage = "El rol es un campo obligatorio")]
        public int Rol { get; set; }
        [Required(ErrorMessage = "La clave es un campo obligatorio")]
        public string Clave { get; set; }   

    }
}
