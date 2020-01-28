﻿using Optivem.Atomiv.Core.Domain;

namespace Optivem.Generator.Core.Domain.Orders
{
    public interface IOrderRepository : ICrudRepository<Order, OrderIdentity>, IPageAggregatesRepository<Order, OrderIdentity>
    {
    }
}