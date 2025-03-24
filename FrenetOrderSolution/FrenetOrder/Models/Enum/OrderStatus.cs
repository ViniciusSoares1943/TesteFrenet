using System.ComponentModel;

namespace FrenetOrder.Models.Enum
{
    /// <summary>
    /// Status do pedido 1-Em processamento, 2-Enviado, 3-Entregue, 4-Cancelado
    /// </summary>
    public enum OrderStatus
    {
        [Description("Em Processamento")]
        Processing = 1,

        [Description("Enviado")]
        Shipped = 2,

        [Description("Entregue")]
        Delivered = 3,

        [Description("Cancelado")]
        Cancelled = 4,
    }
}
