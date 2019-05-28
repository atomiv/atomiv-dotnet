using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Core.Domain
{
    public abstract class BaseValueObject : IValueObject
    {
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
