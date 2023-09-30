namespace Univan.Infrastructure.Security
{
    public class JwtSettings
    {
        public const string JwtSectionName = "JwtSettings";
        public string Secret { get; set; }
        public int ExpiryHours { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }
    }
}
