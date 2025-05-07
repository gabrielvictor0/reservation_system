namespace reservation_system.Services
{
    public class JwtSettings
    {
        public string key { get; set; }
        public string issuer { get; set; }

        public string audience { get; set; }

        public int expiresInMinutes {  get; set; }
    }
}
