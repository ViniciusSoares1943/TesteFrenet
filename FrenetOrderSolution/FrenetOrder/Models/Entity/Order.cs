using FrenetOrder.Models.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FrenetOrder.Models.Entity
{
    /// <summary>
    /// Pedidos realizados
    /// </summary>
    [Table("Pedidos")]
    public class Order
    {
        /// <summary>
        /// Identificador do pedido
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Cliente vinculado ao pedido
        /// </summary>
        public Customer Cliente { get; set; }
        /// <summary>
        /// Identificador do cliente vinculado
        /// </summary>
        [Required]
        [ForeignKey(nameof(Cliente))]
        public int IdCliente { get; set; }
        /// <summary>
        /// Origem do pedido
        /// </summary>
        [Required]
        public string Origem { get; set; }
        /// <summary>
        /// Destino do pedido
        /// </summary>
        [Required]
        public string Destino { get; set; }
        /// <summary>
        /// Data de criação do pedido
        /// </summary>
        [Required]
        public DateTime DataCriacao { get; set; }
        /// <summary>
        /// Status do pedido
        /// </summary>
        [Required]
        public OrderStatus Status { get; set; }
    }
}
