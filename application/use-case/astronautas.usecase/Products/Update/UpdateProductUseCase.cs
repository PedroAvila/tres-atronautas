using astronautas.dto;
using astronautas.entity;
using astronautas.port;

namespace astronautas.usecase.Products.Update
{
    public class UpdateProductUseCase : IUpdateProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task Execute(string id, UpdateProductDto dto)
        {
            var existProduct = await _productRepository.GetByIdAsync(id);

            if(existProduct is null) throw new Exception("Product not found");

            var entity = new Product
            {
                Id = id,
                Name = dto.Name,
                Price = dto.Price,
                UserId = dto.UserId
            };

            await _productRepository.UpdateAsync(id, entity);
        }
    }
}
