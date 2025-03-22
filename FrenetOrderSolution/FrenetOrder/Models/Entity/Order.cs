using FrenetOrder.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrenetOrder.Models.Entity
{
    [Table("Pedidos")]
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public Customer Cliente { get; set; }
        [Required]
        public int IdClient { get; set; }
        [Required]
        public string Origem { get; set; }
        [Required]
        public string Destino { get; set; }
        [Required]
        public DateTime DataCriacao { get; set; }
        [Required]
        public OrderStatus Status { get; set; }
    }
}
