using Optivem.Framework.Core.Domain;

namespace Optivem.Template.Core.Domain.Customers
{
    public interface ICustomerFactory : IFactory
    {
        Customer Create(string firstName, string lastName);
    }
}
