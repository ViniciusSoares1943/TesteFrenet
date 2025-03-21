using System.ComponentModel;

namespace FrenetOrder.Models.Enum
{
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
