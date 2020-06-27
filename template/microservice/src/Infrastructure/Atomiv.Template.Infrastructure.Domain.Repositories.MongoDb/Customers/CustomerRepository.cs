using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb.Records;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Atomiv.Template.Infrastructure.Domain.Repositories.MongoDb.Customers
{
    public class CustomerRepository : CustomerReadonlyRepository, ICustomerRepository
    {
        public CustomerRepository(MongoDbContext context) : base(context)
        {
        }

        public Task AddAsync(Customer customer)
        {
            var customerRecord = GetCustomerRecord(customer);

            return Context.Customers.InsertOneAsync(customerRecord);
        }

        public async Task<Customer> FindAsync(CustomerIdentity customerId)
        {
            var customerRecordId = customerId.TryToObjectId();

            if (customerRecordId == null)
            {
                return null;
            }

            var customerRecord = await Context.Customers
                .Find(e => e.Id == customerRecordId)
                .FirstOrDefaultAsync();

            if (customerRecord == null)
            {
                return null;
            }

            return GetCustomer(customerRecord);
        }

        public Task RemoveAsync(CustomerIdentity customerId)
        {
            var customerRecordId = customerId.ToObjectId();

            return Context.Customers
                .DeleteOneAsync(e => e.Id == customerRecordId);
        }

        public Task UpdateAsync(Customer customer)
        {
            var customerRecordId = customer.Id.ToObjectId();

            var customerRecordFilter = Builders<CustomerRecord>.Filter
                .Eq(e => e.Id, customerRecordId);

            var customerRecord = GetCustomerRecord(customer);

            return Context.Customers.FindOneAndReplaceAsync(customerRecordFilter, customerRecord);
        }

        #region Helper

        private CustomerRecord GetCustomerRecord(Customer customer)
        {
            return new CustomerRecord
            {
                Id = customer.Id.ToObjectId(),
                FirstName = customer.FirstName,
                LastName = customer.LastName,
            };
        }

        private void UpdateCustomerRecord(CustomerRecord customerRecord, Customer customer)
        {
            customerRecord.Id = customer.Id.ToObjectId();
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
