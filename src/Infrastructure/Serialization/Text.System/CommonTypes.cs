using System;

namespace Optivem.Infrastructure.Serialization.Text.System
{
    /// <summary>
    /// Container for common data types
    /// </summary>
    public static class CommonTypes
    {
        public static readonly Type String = typeof(string);

        public static readonly Type Bool = typeof(bool);

        public static readonly Type Short = typeof(short);

        public static readonly Type Int = typeof(int);

        public static readonly Type Long = typeof(long);

        public static readonly Type Float = typeof(float);

        public static readonly Type Double = typeof(double);

        public static readonly Type DateTime = typeof(DateTime);

        public static readonly Type Enum = typeof(Enum);
    }
}
