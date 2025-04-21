using System.Security.Claims;
using astronautas.dto;
using astronautas.usecase.Products.Create;
using astronautas.usecase.Products.Get;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace astronautas.api.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ICreateProductUseCase _createProductUseCase;
        private readonly IGetProductUseCase _getProductUseCase;

        public ProductController(ICreateProductUseCase createProductUseCase, IGetProductUseCase getProductUseCase)
        {
            _createProductUseCase = createProductUseCase;
            _getProductUseCase = getProductUseCase;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateProductDto dto)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            var result = await _createProductUseCase.Execute(dto, userId!);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllByUserId()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return Ok(await _getProductUseCase.Execute(userId!));

        }
    }
}
