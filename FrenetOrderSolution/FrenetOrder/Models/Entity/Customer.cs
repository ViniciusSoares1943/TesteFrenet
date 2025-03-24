using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FrenetOrder.Models.Entity
{
    [Table("Clientes")]
    public class Customer
    {
        /// <summary>
        /// Identificador do cliente
        /// </summary>
        [Key]
        public int Id { get; set; }
        /// <summary>
        /// Nome completo do cliente
        /// </summary>
        [Required]
        public string Nome { get; set; }
        /// <summary>
        /// Endereço do cliente
        /// </summary>
        [Required]
        public string Endereco { get; set; }
        /// <summary>
        /// Telefone do cliente
        /// </summary>
        [Required]
        public string Telefone { get; set; }
        /// <summary>
        /// E-mail do cliente
        /// </summary>
        [Required]
        public string Email { get; set; }
        /// <summary>
        /// Lista de pedidos vinculados ao cliente
        /// </summary>
        public List<Order>? Pedidos { get; set; }
    }
}
