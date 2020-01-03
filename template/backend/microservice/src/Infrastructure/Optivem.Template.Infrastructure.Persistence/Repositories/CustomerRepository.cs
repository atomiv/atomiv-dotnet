using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Infrastructure.Persistence.Records;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.Persistence.Repositories
{
    public class CustomerRepository : CustomerReadRepository, ICustomerRepository
    {
        public CustomerRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task AddAsync(Customer customer)
        {
            var customerRecord = GetCustomerRecord(customer);
            Context.Customers.Add(customerRecord);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(CustomerIdentity customerId)
        {
            var customerRecord = GetCustomerRecord(customerId);
            Context.Remove(customerRecord);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            var customerRecord = await Context.Customers
                .FirstOrDefaultAsync(e => e.Id == customer.Id);

            UpdateCustomerRecord(customerRecord, customer);

            try
            {
                Context.Customers.Update(customerRecord);
                await Context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                throw new ConcurrentUpdateException(ex.Message, ex);
            }
        }

        private CustomerRecord GetCustomerRecord(Customer customer)
        {
            return new CustomerRecord
            {
                Id = customer.Id,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
            };
        }

        private CustomerRecord GetCustomerRecord(CustomerIdentity customerId)
        {
            return new CustomerRecord
            {
                Id = customerId,
            };
        }

        private void UpdateCustomerRecord(CustomerRecord customerRecord, Customer customer)
        {
            customerRecord.Id = customer.Id;
            customerRecord.FirstName = customer.FirstName;
            customerRecord.LastName = customer.LastName;
        }
    }
}