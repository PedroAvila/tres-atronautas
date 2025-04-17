using System.Security.Claims;
using astronautas.dto;
using astronautas.usecase.Products.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace astronautas.api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICreateProductUseCase _createProductUseCase;

        public ProductController(ICreateProductUseCase createProductUseCase)
        {
            _createProductUseCase = createProductUseCase;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await _createProductUseCase.Execute(dto, userId!);
            return Ok(result);
        }
    }
}
