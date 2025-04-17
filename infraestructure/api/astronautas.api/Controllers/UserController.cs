using astronautas.usecase.Users;
using Microsoft.AspNetCore.Mvc;

namespace astronautas.api.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICreateUserUseCase _createUserUseCase;

        public UserController(ICreateUserUseCase createUserUseCase)
        {
            _createUserUseCase = createUserUseCase;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserDto dto)
        {
            var result = await _createUserUseCase.Execute(dto);
            return Ok(result);
        }
    }
}
