using Atomiv.Infrastructure.MongoDB;
using System;

namespace Atomiv.Template.Infrastructure.Domain.Persistence.MongoDB.Records
{
    public class CustomerRecord : Record<Guid>
    {
        public string ReferenceNumber { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
