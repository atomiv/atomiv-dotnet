using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Common.Orders;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Infrastructure.Persistence.Records;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.Persistence.Repositories
{
    public class CustomerReadRepository : Repository, ICustomerReadRepository
    {
        public CustomerReadRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<bool> ExistsAsync(CustomerIdentity customerId)
        {
            var customerRecordId = customerId.Value;

            return Context.Customers.AsNoTracking()
                .AnyAsync(e => e.Id == customerRecordId);
        }

        public async Task<Customer> FindAsync(CustomerIdentity customerId)
        {
            var customerRecordId = customerId.Value;

            var customerRecord = await Context.Customers.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == customerRecordId);

            if(customerRecord == null)
            {
                return null;
            }

            return GetCustomer(customerRecord);
        }

        public async Task<CustomerDetailReadModel> GetDetailAsync(CustomerIdentity customerId)
        {
            var customerRecordId = customerId.Value;

            var customerRecord = await Context.Customers.AsNoTracking()
                .Include(e => e.Orders)
                    .ThenInclude(e => e.OrderItems)
                        .ThenInclude(e => e.Product)
                .FirstOrDefaultAsync(e => e.Id == customerRecordId);

            if(customerRecord == null)
            {
                return null;
            }

            return GetCustomerDetailReadModel(customerRecord);
        }

        public async Task<PageReadModel<CustomerHeaderReadModel>> GetPageAsync(PageQuery pageQuery)
        {
            var customerRecords = await Context.Customers.AsNoTracking()
                .Page(pageQuery)
                .ToListAsync();

            var customerHeaderReadModels = customerRecords
                .Select(GetCustomerHeaderReadModel)
                .ToList();

            var totalRecords = await CountAsync();

            return PageReadModel<CustomerHeaderReadModel>.Create(pageQuery, customerHeaderReadModels, totalRecords);

        }

        public async Task<ListReadModel<CustomerIdNameReadModel>> ListAsync(string nameSearch, int limit)
        {
            var customerRecords = await Context.Customers.AsNoTracking()
                .Where(e => e.FirstName.Contains(nameSearch) || e.LastName.Contains(nameSearch))
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .Take(limit)
                .ToListAsync();

            var resultRecords = customerRecords.Select(GetIdNameResult).ToList();
            var totalRecords = await CountAsync();

            return new ListReadModel<CustomerIdNameReadModel>(resultRecords, totalRecords);
        }

        public Task<long> CountAsync()
        {
            return Context.Customers.LongCountAsync();
        }

        #region Helper

        private CustomerIdNameReadModel GetIdNameResult(CustomerRecord customerRecord)
        {
            var id = new CustomerIdentity(customerRecord.Id);
            var name = $"{customerRecord.FirstName} {customerRecord.LastName}";
            return new CustomerIdNameReadModel(id, name);
        }

        private Customer GetCustomer(CustomerRecord customerRecord)
        {
            var identity = new CustomerIdentity(customerRecord.Id);
            var firstName = customerRecord.FirstName;
            var lastName = customerRecord.LastName;

            return new Customer(identity, firstName, lastName);
        }

        private CustomerHeaderReadModel GetCustomerHeaderReadModel(CustomerRecord customerRecord)
        {
            var id = new CustomerIdentity(customerRecord.Id);
            var firstName = customerRecord.FirstName;
            var lastName = customerRecord.LastName;

            var openOrders = customerRecord.Orders
                .Where(e => e.OrderStatusId != OrderStatus.Closed)
                .Count();

            return new CustomerHeaderReadModel(id, firstName, lastName, openOrders);
        }

        private CustomerDetailReadModel GetCustomerDetailReadModel(CustomerRecord customerRecord)
        {
            var id = new CustomerIdentity(customerRecord.Id);
            var firstName = customerRecord.FirstName;
            var lastName = customerRecord.LastName;

            var openOrders = customerRecord.Orders
                .Where(e => e.OrderStatusId != OrderStatus.Closed)
                .Count();

            var lastOrderDate = customerRecord.Orders
                .Max(e => (DateTime?)e.OrderDate);

            var totalOrders = customerRecord.Orders
                .Count;

            var totalOrderValue = customerRecord.Orders
                .SelectMany(e => e.OrderItems)
                .Select(e => e.UnitPrice * e.Quantity)
                .Sum(e => (decimal?)e)
                .GetValueOrDefault();

            var topProducts = customerRecord.Orders
                .SelectMany(e => e.OrderItems)
                .GroupBy(e => e.Product)
                .OrderByDescending(e => e.Count())
                .Select(e => e.Key.ProductName)
                .ToList();

            return new CustomerDetailReadModel(id, firstName, lastName, openOrders, lastOrderDate, totalOrders, totalOrderValue, topProducts);
        }

        #endregion
    }
}
