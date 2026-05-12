using Finantial_Manager_API.DTOs.User.Auth;
using Finantial_Manager_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finantial_Manager_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService) => _authService = authService;

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserRegisterRequestDTO dto)
        {
            try
            { 
                var result = await _authService.RegisterAsync(dto);
                return Created(string.Empty, result);
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginRequestDTO dto)
        {
            try 
            {
                var result = await _authService.LoginAsync(dto);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }
        }
    }
}
