using Microsoft.Extensions.Configuration;
using MongoDB.Bson.Serialization.Conventions;
using MongoDB.Driver;
using Property365.Common;
using StockManager.Abstractions.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockManager.Infrastructure
{
    public class MongoContext
    {
        public IMongoDatabase Database { get; }
        private readonly ConventionPack camelConventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
        private readonly ConventionPack ignoreExtraElementsPack = new ConventionPack { new IgnoreExtraElementsConvention(true) };
        private readonly ConventionPack ignoreNullsPack = new ConventionPack { new IgnoreIfNullConvention(true) };
        private readonly MongoClient client;

        public MongoContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("StockManagerDatabase");

            ConventionPack pack = new ConventionPack
            {
                new IgnoreIfNullConvention(true),
                new IgnoreExtraElementsConvention(true),
                new CamelCaseElementNameConvention()
            };
            ConventionRegistry.Register("defaults", pack, t => true);
            client = new MongoClient(connectionString);
            Database = client.GetDatabase(MongoUrl.Create(connectionString).DatabaseName);
        }

        public MongoContext(string connectionString)
        {
            ConventionRegistry.Register("CamelCaseConvensions", camelConventionPack, t => true);
            ConventionRegistry.Register("IgnoreExtraElements", ignoreExtraElementsPack, t => true);
            ConventionRegistry.Register("Ignore null values", ignoreNullsPack, t => true);
            client = new MongoClient(connectionString);
            Database = client.GetDatabase(MongoUrl.Create(connectionString).DatabaseName);
        }
        public IMongoCollection<EventRecord> ProductEvents => Database.GetCollection<EventRecord>("ProductEvents");
        public IMongoCollection<ProductRegistrationState> ProductRegistrations => Database.GetCollection<ProductRegistrationState>("ProductRegistrations");
    }
    }
