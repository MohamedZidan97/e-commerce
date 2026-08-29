using Catalog.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Core.Repositories
{
    public interface IProductRepository
    {
        // get all product 
        Task<IEnumerable<Product>> GetAllProducts();
        Task<IEnumerable<Product>> GetAllProductsByName(string name);
        Task<IEnumerable<Product>> GetAllProductsByBrand(string brand);

        Task<Product> GetProductById(string id);

        Task<Product> CreateProduct(Product product);

        Task<bool> UpdateProduct(Product product);

        Task<bool> DeleteProduct(string id);

    }
}