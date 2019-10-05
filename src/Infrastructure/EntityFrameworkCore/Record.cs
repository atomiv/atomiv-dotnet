using Optivem.Framework.Infrastructure.System.Reflection;

namespace Optivem.Framework.Infrastructure.EntityFrameworkCore
{
    public class Record<TId> : IRecord<TId>
    {
        public TId Id { get; set; }

        public override string ToString()
        {
            return PropertyMapper.Instance.ToString(this);
        }
    }
}
