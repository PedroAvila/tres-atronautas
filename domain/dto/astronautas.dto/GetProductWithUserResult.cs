namespace astronautas.dto
{
    public record GetProductWithUserResult(IEnumerable<ProductDto> Products, UserDto User);
   
}
