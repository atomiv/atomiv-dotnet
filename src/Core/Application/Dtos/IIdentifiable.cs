using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Application.Dtos
{
    public interface IIdentifiable<TKey>
    {
        TKey Id { get; set; }
    }
}
