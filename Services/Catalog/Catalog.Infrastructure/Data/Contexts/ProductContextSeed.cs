using Catalog.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.Contexts
{
    internal class ProductContextSeed
    {
         public static async Task SeedDataAsync(IMongoCollection<Product> productCollection)
        {
            var hasProducts = await productCollection.Find(_ => true).AnyAsync();
            if (hasProducts) return;

            var filePath = Path.Combine("Data", "SeedData", "products.json");

            if (!File.Exists(filePath)) {
                Console.WriteLine($"the path is not found:{filePath}");
                return;
            }

            var productData = await File.ReadAllTextAsync(filePath);
            var products = JsonSerializer.Deserialize<List<Product>>(productData);


            if (products?.Any() == true) {
                await productCollection.InsertManyAsync(products);
            }
      
        
        }
    }
    
}
