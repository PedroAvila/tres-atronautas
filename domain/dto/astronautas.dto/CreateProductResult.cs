using System;

namespace astronautas.dto;

public record CreateProductResult(string Id, string Name, decimal Price, string UserId);
