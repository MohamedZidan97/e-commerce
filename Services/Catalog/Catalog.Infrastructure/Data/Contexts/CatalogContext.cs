using Catalog.Core.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Infrastructure.Data.Contexts
{
    public class CatalogContext : ICatalogContext
    {
        public IMongoCollection<Product> Products {  get; }

        public IMongoCollection<ProductBrand> Brands { get; }

        public IMongoCollection<ProductType> Types {  get; }

        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSetting:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSetting:DatabaseName"]);

            Brands = database.GetCollection<ProductBrand>(configuration["DatabaseSetting:BrandCollection"]);
            Types = database.GetCollection<ProductType>(configuration["DatabaseSetting:TypeCollection"]);
            Products = database.GetCollection<Product>(configuration["DatabaseSetting:ProductCollection"]);




            // check on primary data inside database, if not found seed them from seedData Filed.
            _ = BrandContextSeed.SeedDataAsync(Brands);
            _ = TypeContextSeed.SeedDataAsync(Types);
            _ = ProductContextSeed.SeedDataAsync(Products);





        }
    }
}
