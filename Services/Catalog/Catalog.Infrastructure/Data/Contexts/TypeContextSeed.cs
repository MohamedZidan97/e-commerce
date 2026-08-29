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
    public static class TypeContextSeed
    {
        public static async Task SeedDataAsync(IMongoCollection<ProductType> typeCollection)
        {
            var hasTypes = await typeCollection.Find(_ => true).AnyAsync();
            if (hasTypes) return;

            var filePath = Path.Combine("Data", "SeedData", "types.json");

            if (!File.Exists(filePath))
            {
                Console.WriteLine($"the path is not found:{filePath}");
                return;
            }

            var TypeData = await File.ReadAllTextAsync(filePath);
            var Types = JsonSerializer.Deserialize<List<ProductType>>(TypeData);

            if (Types?.Any() == true)
            {
                await typeCollection.InsertManyAsync(Types);
            }
        }
    }
}
