using System.ComponentModel.DataAnnotations;

namespace DAL
{
    public class ProductoMetadata
    {
        [Required]
        public string Nombre { get; set; }

        [Required]
        public decimal Precio { get; set; }
    }
}