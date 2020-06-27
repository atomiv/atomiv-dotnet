using Microsoft.EntityFrameworkCore;
using Atomiv.Core.Domain;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;
using System.Threading.Tasks;
using Atomiv.Template.Infrastructure.Domain.Persistence;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.Customers
{
    public class CustomerRepository : CustomerReadonlyRepository, ICustomerRepository
    {
        public CustomerRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Customer> FindAsync(CustomerIdentity customerId)
        {
            var customerRecordId = customerId.ToGuid();

            var customerRecord = await Context.Customers.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == customerRecordId);

            if (customerRecord == null)
            {
                return null;
            }

            return GetCustomer(customerRecord);
        }

        public async Task AddAsync(Customer customer)
        {
            var customerRecord = GetCustomerRecord(customer);
            Context.Customers.Add(customerRecord);
            await Context.SaveChangesAsync();
        }

        public async Task RemoveAsync(CustomerIdentity customerId)
        {
            var customerRecordId = customerId.ToGuid();

            var customerRecord = await Context.Customers
                .FirstOrDefaultAsync(e => e.Id == customerRecordId);

            Context.Remove(customerRecord);
            await Context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Customer customer)
        {
            var customerRecordId = customer.Id.ToGuid();

            var customerRecord = await Context.Customers
                .FirstOrDefaultAsync(e => e.Id == customerRecordId);

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

        #region Helper

        private CustomerRecord GetCustomerRecord(Customer customer)
        {
            return new CustomerRecord
            {
                Id = customer.Id.ToGuid(),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
            };
        }

        private void UpdateCustomerRecord(CustomerRecord customerRecord, Customer customer)
        {
            customerRecord.Id = customer.Id.ToGuid();
            customerRecord.FirstName = customer.FirstName;
            customerRecord.LastName = customer.LastName;
        }

        private Customer GetCustomer(CustomerRecord customerRecord)
        {
            var identity = new CustomerIdentity(customerRecord.Id.ToString());
            var firstName = customerRecord.FirstName;
            var lastName = customerRecord.LastName;

            return new Customer(identity, firstName, lastName);
        }

        #endregion
    }
}