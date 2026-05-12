using System.ComponentModel.DataAnnotations;

namespace Finantial_Manager_API.DTOs.User.Auth
{
    public class UserRegisterRequestDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required, MinLength(8)]
        public string Password { get; set; } = string.Empty;

        [MaxLength(3)]
        public string CurrencyPreference { get; set; } = "BRL";
    }
}
