using System;

namespace Atomiv.Infrastructure.System.IntegrationTest.Fixtures
{
    public class CustomerRecord
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public decimal AccountBalance { get; set; }

        public DateTime? DateJoined { get; set; }

        public bool IsActive { get; set; }
    }
}