using astronautas.dto;
using astronautas.entity;
using astronautas.port;

namespace astronautas.usecase.Products.Create;

public class CreateProductUseCase : ICreateProductUseCase
{
    private readonly IProductRepository _productRepository;

    public CreateProductUseCase(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<CreateProductResult> Execute(CreateProductDto dto, string userId)
    {
        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            UserId = userId,
        };

        var newProduct = await _productRepository.CreateAsync(product);
        return new CreateProductResult(
            newProduct.Id!,
            newProduct.Name!,
            newProduct.Price,
            newProduct.UserId!
        );
    }
}
