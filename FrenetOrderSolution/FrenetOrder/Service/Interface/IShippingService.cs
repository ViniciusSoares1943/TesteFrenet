using FrenetOrder.Models.Dto;

namespace FrenetOrder.Service.Interface
{
    public interface IShippingService
    {
        public Task<List<ShippingSevices>> ShippingCalculate(ShippingCalculateInput input);

    }
}
