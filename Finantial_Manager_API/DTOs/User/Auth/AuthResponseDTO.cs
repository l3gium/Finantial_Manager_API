namespace Finantial_Manager_API.DTOs.User.Auth
{
    public class AuthResponseDTO
    {
        public string Token { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;   
        public string CurrencyPreference { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
    }
}
