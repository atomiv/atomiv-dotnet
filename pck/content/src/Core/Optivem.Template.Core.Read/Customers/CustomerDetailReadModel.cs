using System;
using System.Collections.Generic;

namespace Optivem.Template.Core.Domain.Customers
{
    public class CustomerDetailReadModel
    {
        public CustomerDetailReadModel(CustomerIdentity id, string firstName, string lastName, int openOrders, DateTime? lastOrderDate, int totalOrders, decimal totalOrderValue, IEnumerable<string> topProducts)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            OpenOrders = openOrders;
            LastOrderDate = lastOrderDate;
            TotalOrders = totalOrders;
            TotalOrderValue = totalOrderValue;
            TopProducts = topProducts;
        }

        public CustomerIdentity Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public int OpenOrders { get; }

        public DateTime? LastOrderDate { get; }

        public int TotalOrders { get; }

        public decimal TotalOrderValue { get; }

        public IEnumerable<string> TopProducts { get; }
    }
}
