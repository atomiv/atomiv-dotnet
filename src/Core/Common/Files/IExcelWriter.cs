using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Common.Files
{
    public interface IExcelWriter
    {
        void Write(string path, ExcelFile file);
    }
}
