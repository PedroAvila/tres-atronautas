using astronautas.dto;
using astronautas.port;

namespace astronautas.usecase.Products.Get;

public class GetProductUseCase : IGetProductUseCase
{
    private readonly IProductRepository _productRepository;
    private readonly IUserRepository _userRepository;

    public GetProductUseCase(IProductRepository productRepository, IUserRepository userRepository)
    {
        _productRepository = productRepository;
        _userRepository = userRepository;
    }

    public async Task<GetProductWithUserResult> Execute(string userId)
    {
        IEnumerable<ProductDto> productsDto = Enumerable.Empty<ProductDto>(); 
        var products = await _productRepository.ProductsByUserIdAsync(userId);
        if (products != null && products.Any()) 
        {
            productsDto = products.Select(p => new ProductDto(p.Id!, p.Name!, p.Price, p.UserId));
        }

        var user = await _userRepository.GetByIdAsync(userId);

        return new GetProductWithUserResult(productsDto, new UserDto(user.Id!, user.Name!, user.Email!));
    }
}
