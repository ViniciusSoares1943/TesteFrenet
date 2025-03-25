namespace FrenetOrder.Service.Interface
{
    public interface IJwtService
    {
        public string GenerateToken(string userId, string login);
    }
}
