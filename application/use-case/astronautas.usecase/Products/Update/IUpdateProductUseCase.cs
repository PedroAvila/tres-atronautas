using astronautas.dto;

namespace astronautas.usecase.Products.Update
{
    public interface IUpdateProductUseCase
    {
        Task Execute(string id, UpdateProductDto dto);

    }
}
