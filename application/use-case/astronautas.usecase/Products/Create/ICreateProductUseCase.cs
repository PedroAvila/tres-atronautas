using System;
using astronautas.dto;

namespace astronautas.usecase.Products.Create;

public interface ICreateProductUseCase
{
    Task<CreateProductResult> Execute(CreateProductDto dto, string userId);
}
