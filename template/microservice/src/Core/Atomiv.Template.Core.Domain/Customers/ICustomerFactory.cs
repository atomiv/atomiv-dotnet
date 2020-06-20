using Atomiv.Core.Domain;

namespace Atomiv.Template.Core.Domain.Customers
{
    public interface ICustomerFactory : IFactory
    {
        Customer Create(string firstName, string lastName);
    }
}
