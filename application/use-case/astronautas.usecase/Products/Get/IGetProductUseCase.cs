using astronautas.dto;

namespace astronautas.usecase.Products.Get;

public interface IGetProductUseCase { 

    Task<GetProductWithUserResult> Execute(string userId);
}
