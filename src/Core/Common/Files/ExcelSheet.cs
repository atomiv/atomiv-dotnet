using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Common.Files
{
    public class ExcelSheet
    {
        public ExcelSheet(string name, object[,] data)
        {
            Name = name;
            Data = data;
        }

        public string Name { get; }

        public object[,] Data { get; }
    }
}
