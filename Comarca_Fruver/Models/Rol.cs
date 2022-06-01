using System.ComponentModel.DataAnnotations;

namespace Comarca_Fruver.Models
{
    public class Rol
    {
        [Key]
        public int RolID { get; set; }
        public string NombreRol { get; set; }
    }
}
