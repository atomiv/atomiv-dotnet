using System;
using System.Collections.Generic;
using System.Text;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb
{
    public class MongoDbOptions
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
