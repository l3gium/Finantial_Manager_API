using Finantial_Manager_API.DTOs.User.Auth;

namespace Finantial_Manager_API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResponseDTO> RegisterAsync(UserRegisterRequestDTO dto);
        Task<AuthResponseDTO> LoginAsync(UserLoginRequestDTO dto);
    }
}
