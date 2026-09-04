using Catalog.Core.Entities;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data.Contexts;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository, IBrandRepository, ITypeRepository
    {
        private readonly CatalogContext _context;

        public ProductRepository(CatalogContext context)
        {
            _context = context;
        }

        // =========================
        // Products
        // =========================

        public async Task<Product> CreateProduct(Product product)
        {
            await _context.Products.InsertOneAsync(product);

            return product;
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            var result = await _context.Products.DeleteOneAsync(filter);

            return result.DeletedCount > 0;
        }

        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _context.Products
                .Find(_ => true)
                .ToListAsync();
        }

        public async Task<Product> GetProductById(string id)
        {
            var filter = Builders<Product>.Filter.Eq(p => p.Id, id);

            return await _context.Products
                .Find(filter)
                .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsByBrand(string brand)
        {
            var filter = Builders<Product>.Filter.Eq(
                p => p.Brand.Name,
                brand
            );

            return await _context.Products
                .Find(filter)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsByName(string name)
        {
            var filter = Builders<Product>.Filter.Regex(
                p => p.Name,
                new MongoDB.Bson.BsonRegularExpression(name, "i")
            );

            return await _context.Products
                .Find(filter)
                .ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            // generate filter
            var filter = Builders<Product>.Filter.Eq(
                p => p.Id,
                product.Id
            );
            //
            var result = await _context.Products.ReplaceOneAsync(
                filter,
                product
            );

            return result.ModifiedCount > 0;
        }


        // =========================
        // Brands
        // =========================

        public async Task<IEnumerable<ProductBrand>> GetAllProductBrand()
        {
            return await _context.Brands
                .Find(_ => true)
                .ToListAsync();
        }


        // =========================
        // Types
        // =========================

        public async Task<IEnumerable<ProductType>> GetAllProductTypes()
        {
            return await _context.Types
                .Find(_ => true)
                .ToListAsync();
        }
    }
}
