using astronautas.adapter;
using astronautas.common;
using astronautas.port;
using astronautas.service;
using astronautas.usecase.Products.Create;
using astronautas.usecase.Products.Get;
using astronautas.usecase.Users;
using astronautas.usecase.Users.Auth;

namespace astronautas.api.Extensions;

public static class ApplicationServiceExtensions
{
    public static void AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
        services.AddScoped<ICreateUserUseCase, CreateUserUseCase>();
        services.AddScoped<IKeyEncryptor, KeyEncryptor>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ILoginUseCase, LoginUseCase>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IJwtService, JwtService>();

        /* Product */
        services.AddScoped<ICreateProductUseCase, CreateProductUseCase>();
        services.AddScoped<IGetProductUseCase, GetProductUseCase>();
        services.AddScoped<IProductRepository, ProductRepository>();
    }
}
