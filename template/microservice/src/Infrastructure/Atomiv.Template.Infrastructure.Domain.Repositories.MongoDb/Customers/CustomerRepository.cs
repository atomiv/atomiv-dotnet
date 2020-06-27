using Atomiv.Template.Core.Domain.Customers;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb;
using Atomiv.Template.Infrastructure.Domain.Persistence.MongoDb.Records;
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
            throw new NotImplementedException();
        }

        public Task<Customer> FindAsync(CustomerIdentity customerId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(CustomerIdentity customerId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Customer customer)
        {
            throw new NotImplementedException();
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
