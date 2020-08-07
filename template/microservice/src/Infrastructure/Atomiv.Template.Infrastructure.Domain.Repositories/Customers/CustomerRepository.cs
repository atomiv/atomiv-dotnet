using Microsoft.EntityFrameworkCore;
using Atomiv.Core.Domain;
using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Infrastructure.Domain.Persistence.Common;
using Atomiv.Template.Infrastructure.Domain.Persistence.Records;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.Customers
{
    public class CustomerRepository : CustomerReadonlyRepository, ICustomerRepository
    {
        public CustomerRepository(DatabaseContext context) : base(context)
        {
        }

        public async Task<Customer> FindAsync(CustomerIdentity customerId)
        {
            var customerRecord = await Context.Customers.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == customerId);

            if (customerRecord == null)
            {
                return null;
            }

            return GetCustomer(customerRecord);
        }

        public Task AddAsync(Customer customer)
        {
            var customerRecord = GetCustomerRecord(customer);
            Context.Customers.Add(customerRecord);
            return Task.CompletedTask;
        }

        public async Task RemoveAsync(CustomerIdentity customerId)
        {
            var customerRecord = await Context.Customers
                .FirstOrDefaultAsync(e => e.Id == customerId);

            Context.Remove(customerRecord);
        }

        public async Task UpdateAsync(Customer customer)
        {
            var customerRecord = await Context.Customers
                .FirstOrDefaultAsync(e => e.Id == customer.Id);

            UpdateCustomerRecord(customerRecord, customer);

            Context.Customers.Update(customerRecord);
        }

        #region Helper

        private CustomerRecord GetCustomerRecord(Customer customer)
        {
            return new CustomerRecord
            {
                Id = customer.Id,
                ReferenceNumber = customer.ReferenceNumber.ToString(),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
            };
        }

        private void UpdateCustomerRecord(CustomerRecord customerRecord, Customer customer)
        {
            customerRecord.Id = customer.Id;
            customerRecord.ReferenceNumber = customer.ReferenceNumber.ToString();
            customerRecord.FirstName = customer.FirstName;
            customerRecord.LastName = customer.LastName;
        }

        private Customer GetCustomer(CustomerRecord customerRecord)
        {
            var id = new CustomerIdentity(customerRecord.Id);
            var referenceNumber = CustomerReferenceNumber.Parse(customerRecord.ReferenceNumber);
            var firstName = customerRecord.FirstName;
            var lastName = customerRecord.LastName;

            return new Customer(id, referenceNumber, firstName, lastName);
        }

        #endregion
    }
}