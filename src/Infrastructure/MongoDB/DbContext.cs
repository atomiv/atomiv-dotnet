using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Infrastructure.MongoDB
{
    public class DbContext
    {
        public DbContext(IOptions<MongoDBOptions> options)
        {
            var config = options.Value;

            Client = new MongoClient(config.ConnectionString);
            Database = Client.GetDatabase(config.DatabaseName);
        }

        public IMongoClient Client { get; }

        public IMongoDatabase Database { get; }
    }
}
