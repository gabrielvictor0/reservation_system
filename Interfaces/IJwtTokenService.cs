namespace reservation_system.Interfaces
{
    public interface IJwtTokenService
    {
        string GenerateToken(int userId, string username, string roles);
    }
}
