using System.ComponentModel.DataAnnotations;

namespace Comarca_Fruver.Models
{
    public class Cargamento
    {
        [Key]
        [Required(ErrorMessage ="El Id del cargamento es obligatorio")]
        public int IdCargamento { get; set; }

        [Required(ErrorMessage = "El número de pedido es obligatorio")]
        [Display(Name ="Numero de pedido")]
        public int NumeroPedido { get; set; } 
        
        [Required(ErrorMessage ="El nombre del producto es obligatorio")]
        public string? Producto { get; set; }

        [Required(ErrorMessage = "El peso del producto es obligatorio")]
        [Display(Name = "Peso (tn)")]
        public int Peso { get; set; }

        [Required(ErrorMessage = "El lugar de origen es obligatorio")]
        public string? Origen { get; set; }

    }
}
