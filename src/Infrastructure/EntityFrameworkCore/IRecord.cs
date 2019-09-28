using Optivem.Framework.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public interface IRecord : IIdentity
    {

    }

    public interface IRecord<TId> : IRecord, IIdentity<TId>
    {
    }
}
