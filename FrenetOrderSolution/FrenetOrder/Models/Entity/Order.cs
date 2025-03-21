using FrenetOrder.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace FrenetOrder.Models.Entity
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public Customer Cliente { get; set; }
        public int IdClient { get; set; }
        public string Origem { get; set; }
        public string Destino { get; set; }
        public DateTime DataCriacao { get; set; }
        public OrderStatus Status { get; set; }
    }
}
