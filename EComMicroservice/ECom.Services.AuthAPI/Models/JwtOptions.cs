namespace ECom.Services.AuthAPI.Models
{
    public class JwtOptions
    {
        public string Issuer { get; set; } = string.Empty;
        public string Audience { get; set; } = string.Empty;
        public string Secrect { get; set; } = string.Empty;
    }
}
