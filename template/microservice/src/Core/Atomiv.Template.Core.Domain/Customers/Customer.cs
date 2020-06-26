using Atomiv.Core.Domain;

namespace Atomiv.Template.Core.Domain.Customers
{
    public class Customer : Entity<CustomerIdentity>
    {
        private string _firstName;
        private string _lastName;

        public Customer(CustomerIdentity id, string firstName, string lastName)
            : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                if(string.IsNullOrEmpty(value))
                {
                    throw new DomainException("First name cannot null or empty");
                }

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
                if (string.IsNullOrEmpty(value))
                {
                    throw new DomainException("Last name cannot null or empty");
                }

                _lastName = value;
            }
        }
    }
}