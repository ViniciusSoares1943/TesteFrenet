using FrenetOrder.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace FrenetOrder.Models.Dto
{
    public class OrderUpdateInput
    {
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
        /// Status do pedido
        /// </summary>
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus Status { get; set; }
    }
}
