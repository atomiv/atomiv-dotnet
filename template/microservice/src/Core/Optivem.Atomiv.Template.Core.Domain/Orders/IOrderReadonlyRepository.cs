using Optivem.Atomiv.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Optivem.Atomiv.Template.Core.Domain.Orders
{
    public interface IOrderReadonlyRepository : IRepository
    {
        Task<bool> ExistsAsync(Guid orderId);

        Task<long> CountAsync();
    }
}
