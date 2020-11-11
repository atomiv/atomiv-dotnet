using Atomiv.Core.Domain;

namespace Atomiv.Template.Core.Domain.Customers
{
    public class Customer : Entity<CustomerIdentity>
    {
        private string _firstName;
        private string _lastName;

        public Customer(CustomerIdentity id, 
            CustomerReferenceNumber referenceNumber,
            string firstName,
            string lastName,
            bool isNew = false)
            : base(id, isNew)
        {
            ValidateReferenceNumber(referenceNumber);

            ReferenceNumber = referenceNumber;
            FirstName = firstName;
            LastName = lastName;
        }

        public CustomerReferenceNumber ReferenceNumber { get; }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                ValidateFirstName(value);
                _firstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                ValidateLastName(value);
                _lastName = value;
            }
        }

        private void ValidateReferenceNumber(CustomerReferenceNumber referenceNumber)
        {
            if(referenceNumber == null)
            {
                throw new DomainException("Reference number cannot null");
            }
        }

        private void ValidateFirstName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new DomainException("First name cannot null or empty");
            }
        }

        private void ValidateLastName(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new DomainException("Last name cannot null or empty");
            }
        }
    }
}