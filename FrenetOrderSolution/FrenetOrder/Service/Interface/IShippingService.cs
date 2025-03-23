namespace FrenetOrder.Service.Interface
{
    public interface IShippingService
    {
        public Task<string> Calculate();

    }
}
