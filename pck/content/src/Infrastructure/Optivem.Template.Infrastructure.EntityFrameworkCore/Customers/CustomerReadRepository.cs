using Microsoft.EntityFrameworkCore;
using Optivem.Framework.Core.Domain;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;
using Optivem.Template.Core.Domain.Orders;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers
{
    public class CustomerReadRepository : Repository, ICustomerReadRepository
    {
        // TODO: VC: Add enums into EF https://github.com/optivem/framework-dotnetcore/issues/355
        private const byte ClosedOrderStatusRecordId = (byte)OrderStatus.Closed;

        public CustomerReadRepository(DatabaseContext context) : base(context)
        {
        }

        public Task<bool> ExistsAsync(CustomerIdentity customerId)
        {
            var customerRecordId = customerId.Id;

            return Context.CustomerRecords.AsNoTracking()
                .AnyAsync(e => e.Id == customerRecordId);
        }

        public async Task<Customer> FindAsync(CustomerIdentity customerId)
        {
            var customerRecordId = customerId.Id;

            var customerRecord = await Context.CustomerRecords.AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == customerRecordId);

            if(customerRecord == null)
            {
                return null;
            }

            return GetCustomer(customerRecord);
        }

        public async Task<CustomerDetailReadModel> GetDetailAsync(CustomerIdentity customerId)
        {
            var customerRecordId = customerId.Id;

            var customerRecord = await Context.CustomerRecords.AsNoTracking()
                .Include(e => e.OrderRecords)
                    .ThenInclude(e => e.OrderDetailRecords)
                        .ThenInclude(e => e.ProductRecord)
                .FirstOrDefaultAsync(e => e.Id == customerRecordId);

            if(customerRecord == null)
            {
                return null;
            }

            return GetCustomerDetailReadModel(customerRecord);
        }

        public async Task<PageReadModel<CustomerHeaderReadModel>> GetPageAsync(PageQuery pageQuery)
        {
            var customerRecords = await Context.CustomerRecords.AsNoTracking()
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
            var customerRecords = await Context.CustomerRecords.AsNoTracking()
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
            return Context.CustomerRecords.LongCountAsync();
        }

        #region Helper

        private CustomerIdNameReadModel GetIdNameResult(CustomerRecord customerRecord)
        {
            var id = customerRecord.Id;
            var name = $"{customerRecord.FirstName} {customerRecord.LastName}";
            return new CustomerIdNameReadModel(id, name);
        }

        protected Customer GetCustomer(CustomerRecord customerRecord)
        {
            var identity = new CustomerIdentity(customerRecord.Id);
            var firstName = customerRecord.FirstName;
            var lastName = customerRecord.LastName;

            return new Customer(identity, firstName, lastName);
        }

        protected CustomerHeaderReadModel GetCustomerHeaderReadModel(CustomerRecord customerRecord)
        {
            var id = new CustomerIdentity(customerRecord.Id);
            var firstName = customerRecord.FirstName;
            var lastName = customerRecord.LastName;

            var openOrders = customerRecord.OrderRecords
                .Where(e => e.OrderStatusRecordId != ClosedOrderStatusRecordId)
                .Count();

            return new CustomerHeaderReadModel(id, firstName, lastName, openOrders);
        }

        protected CustomerDetailReadModel GetCustomerDetailReadModel(CustomerRecord customerRecord)
        {
            var id = new CustomerIdentity(customerRecord.Id);
            var firstName = customerRecord.FirstName;
            var lastName = customerRecord.LastName;

            var openOrders = customerRecord.OrderRecords
                .Where(e => e.OrderStatusRecordId != ClosedOrderStatusRecordId)
                .Count();

            var lastOrderDate = customerRecord.OrderRecords
                .Max(e => (DateTime?)e.OrderDate);

            var totalOrders = customerRecord.OrderRecords
                .Count;

            var totalOrderValue = customerRecord.OrderRecords
                .SelectMany(e => e.OrderDetailRecords)
                .Select(e => e.UnitPrice * e.Quantity)
                .Sum(e => (decimal?)e)
                .GetValueOrDefault();

            var topProducts = customerRecord.OrderRecords
                .SelectMany(e => e.OrderDetailRecords)
                .GroupBy(e => e.ProductRecord)
                .OrderByDescending(e => e.Count())
                .Select(e => e.Key.ProductName)
                .ToList();

            return new CustomerDetailReadModel(id, firstName, lastName, openOrders, lastOrderDate, totalOrders, totalOrderValue, topProducts);
        }

        #endregion
    }
}
