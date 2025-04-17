using astronautas.common;
using astronautas.usecase.Users.Auth;
using Microsoft.AspNetCore.Mvc;

namespace astronautas.api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginUseCase _loginUseCase;
        private readonly IJwtService _jwtService;

        public AuthController(ILoginUseCase loginUseCase, IJwtService jwtService)
        {
            _jwtService = jwtService;
            _loginUseCase = loginUseCase;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto dto)
        {
            var (isValid, user) = await _loginUseCase.IsValidUserAsync(dto);
            if (!isValid)
                return Unauthorized("Invalid credentials");

            var token = _jwtService.GenerateToken(user.Id!);

            return Ok(new { User = user, Token = token });
        }
    }
}
