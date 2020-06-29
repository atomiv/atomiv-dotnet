using Atomiv.Core.Domain;
using System;
using System.Linq;

namespace Atomiv.Template.Core.Domain.Customers
{
    public class CustomerReferenceNumberGenerator : IGenerator<CustomerReferenceNumber>
    {
        private readonly ITimeService _timeService;
        private readonly Random _random;

        private const int AlphaNumericLength = 5;
        private const string AlphaNumericChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public CustomerReferenceNumberGenerator(ITimeService timeService)
        {
            _timeService = timeService;
            _random = new Random();
        }

        public CustomerReferenceNumber Next()
        {
            var timestamp = _timeService.Now;
            var alphaNumeric = NextAlphaNumeric();

            return new CustomerReferenceNumber(timestamp, alphaNumeric);
        }

        private string NextAlphaNumeric()
        {
            var chars = Enumerable.Range(0, AlphaNumericLength)
                .Select(e => AlphaNumericChars[_random.Next(0, AlphaNumericChars.Length)])
                .ToArray();

            return new string(chars);
        }
    }
}
