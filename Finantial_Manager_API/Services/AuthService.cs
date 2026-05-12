using Finantial_Manager_API.DTOs.User.Auth;
using Finantial_Manager_API.Models;
using Finantial_Manager_API.Repositories.Interfaces;
using Finantial_Manager_API.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Finantial_Manager_API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _configuration;

        public AuthService(IUserRepository userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public Task<AuthResponseDTO> LoginAsync(UserLoginRequestDTO dto)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthResponseDTO> RegisterAsync(UserRegisterRequestDTO dto)
        {
            if (await _userRepository.EmailExistsAsync(dto.Email))
                throw new InvalidOperationException("Email already exists.");

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                CurrencyPreference = dto.CurrencyPreference,
            };

            await _userRepository.CreateAsync(user);

            return GenerateAuthResponse(user);
        }

        private AuthResponseDTO GenerateAuthResponse(User user)
        {
            var token = GenerateJwtToken(user);
            var expiresAt = DateTime.UtcNow.AddHours(
                double.Parse(_configuration["Jwt:ExpiresInHours"]!));

            return new AuthResponseDTO
            {
                Token = token,
                Name = user.Name,
                Email = user.Email,
                CurrencyPreference = user.CurrencyPreference,
                ExpiresAt = expiresAt
            };
        }

        private string GenerateJwtToken(User user)
        {
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Name)
            };

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(
                    double.Parse(_configuration["Jwt:ExpiresInHours"]!)),
                signingCredentials: new SigningCredentials(
                    key, SecurityAlgorithms.HmacSha256)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
