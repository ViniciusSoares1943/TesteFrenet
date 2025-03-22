using FrenetOrder.Models.Enum;
using System.ComponentModel.DataAnnotations;

namespace FrenetOrder.Models.Dto
{
    public class OrderUpdateInput
    {
        [Required]
        public string Origem { get; set; }
        [Required]
        public string Destino { get; set; }
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus Status { get; set; }
    }
}
