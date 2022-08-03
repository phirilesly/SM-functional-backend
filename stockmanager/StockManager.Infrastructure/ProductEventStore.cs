using MongoDB.Driver;
using Property365.Common;
using Property365.Functional;
using StockManager.Abstractions.Products;
using static Property365.Functional.F;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Infrastructure
{
    public class ProductEventStore : IProductEventStore
    {
        private MongoContext _context;
        public ProductEventStore(MongoContext context)
        {
            _context = context;
        }

        public ProductEventStore(string connectionString)
        {
            _context = new MongoContext(connectionString);
        }

        public async Task<Option<IEnumerable<EventRecord>>> GetEvents(Guid entityId)
        {
            FilterDefinition<EventRecord> filter = Builders<EventRecord>.Filter.Eq(e => e.EntityId, entityId);

            //var result = await _context.SchemeEvents.FindAsync((FilterDefinition<EventRecord>)filter);

            var result = await _context.ProductEvents.Find(filter).ToListAsync();

            return result.Any() ? Some(result.AsEnumerable()) : None;

        }

        public async Task Persist(EventRecord @event)
        {
            FilterDefinition<EventRecord> filter = Builders<EventRecord>.Filter.Eq("_id", @event.Id);

            var result = await _context.ProductEvents.FindAsync(filter);

            if (result.Any())
            {
                await _context.ProductEvents.ReplaceOneAsync(filter, @event);
            }
            else
            {
                await _context.ProductEvents.InsertOneAsync(@event);
            }
            return;
        }

        public async Task Persist(IEnumerable<EventRecord> events)
        {
            await _context.ProductEvents.InsertManyAsync(events);
            return;
        }
    }
}
