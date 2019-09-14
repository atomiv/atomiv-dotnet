using Optivem.Framework.Core.Common.Mapping;
using Optivem.Framework.Infrastructure.EntityFrameworkCore;
using Optivem.Template.Core.Domain.Customers;

namespace Optivem.Template.Infrastructure.EntityFrameworkCore.Customers
{
    public class CustomerRepository : CrudRepository<DatabaseContext, Customer, CustomerIdentity, CustomerRecord, int>, ICustomerRepository
    {
        public CustomerRepository(DatabaseContext context, IMapper mapper) 
            : base(context, mapper)
        {
        }
    }
}