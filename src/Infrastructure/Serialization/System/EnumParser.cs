using System;

namespace Optivem.Infrastructure.Serialization.Text.System
{
    // TODO: VC: Base enum constraint

    public class EnumParser<T> : BaseParser<T?> where T : struct
    {
        public EnumParser(bool ignoreCase = false)
        {
            IgnoreCase = ignoreCase;
            Type = typeof(T);
        }
        
        public bool IgnoreCase { get; private set; }

        public Type Type { get; private set; }

        protected override T? ParseInner(string value)
        {
            return (T)Enum.Parse(Type, value, IgnoreCase);
        }

        // TODO: VC: for returning objects: return Enum.Parse(type, data, IgnoreCase);
    }
}
