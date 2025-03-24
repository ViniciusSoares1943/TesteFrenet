using FrenetOrder.Models.Dto;

namespace FrenetOrder.Service.Interface
{
    public interface IShippingService
    {
        public Task<ShippingQuoteResponseEnvelope> Calculate(ShippingCalculateInput input);

    }
}
