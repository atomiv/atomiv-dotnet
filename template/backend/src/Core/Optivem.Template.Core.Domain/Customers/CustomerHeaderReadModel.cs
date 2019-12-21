namespace Optivem.Template.Core.Domain.Customers
{
    public class CustomerHeaderReadModel
    {
        public CustomerHeaderReadModel(CustomerIdentity customerId, string firstName, string lastName, int openOrders)
        {
            CustomerId = customerId;
            FirstName = firstName;
            LastName = lastName;
            OpenOrders = openOrders;
        }

        public CustomerIdentity CustomerId { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public int OpenOrders { get; }
    }
}
