using System;
using astronautas.entity;

namespace astronautas.port;

public interface IProductRepository : IMongoRepository<Product> { }
