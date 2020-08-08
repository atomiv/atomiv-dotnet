using Atomiv.Core.Domain;

namespace Atomiv.Template.Core.Domain.Customers
{
    public class CustomerFactory : ICustomerFactory
    {
        private readonly IGenerator<CustomerIdentity> _customerIdentityGenerator;
        private readonly IGenerator<CustomerReferenceNumber> _customerReferenceNumberGenerator;

        public CustomerFactory(IGenerator<CustomerIdentity> customerIdentityGenerator,
            IGenerator<CustomerReferenceNumber> customerReferenceNumberGenerator)
        {
            _customerIdentityGenerator = customerIdentityGenerator;
            _customerReferenceNumberGenerator = customerReferenceNumberGenerator;
        }

        public Customer CreateCustomer(string firstName, string lastName)
        {
            var id = _customerIdentityGenerator.Next();
            var referenceNumber = _customerReferenceNumberGenerator.Next();

            return new Customer(id, referenceNumber, firstName, lastName, true);
        }
    }
}
