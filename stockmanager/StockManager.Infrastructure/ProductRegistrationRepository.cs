using MongoDB.Driver;
using StockManager.Abstractions.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Infrastructure
{
    public class ProductRegistrationRepository : IProductRegistrationRepository
    {
        private MongoContext _context;
        public ProductRegistrationRepository(MongoContext context)
        {
            _context = context;
        }

        public ProductRegistrationRepository(string connectionString)
        {
            _context = new MongoContext(connectionString);
        }

        public async Task<ProductRegistrationState> GetEntityStateAsync(Guid id)
        {
            FilterDefinition<ProductRegistrationState> filter = Builders<ProductRegistrationState>.Filter.Eq("_id", id);
            if (filter == null)
            {
                throw new ArgumentException("Invalid search parameters specified");
            }

            var result = await _context.ProductRegistrations.FindAsync(filter);
            return result.FirstOrDefault();
        }

        public async Task<Guid> SaveEntityStateAsync(ProductRegistrationState entity)
        {
            FilterDefinition<ProductRegistrationState> filter = Builders<ProductRegistrationState>.Filter.Eq("_id", entity.Id);
            var result = await _context.ProductRegistrations.FindAsync(filter);
            if (result.Any())
            {
                await _context.ProductRegistrations.ReplaceOneAsync(filter, entity);
            }
            else
            {
                await _context.ProductRegistrations.InsertOneAsync(entity);
            }

            return entity.Id;
        }
    }
}
