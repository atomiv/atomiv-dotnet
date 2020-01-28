using System.Collections.Generic;

namespace Optivem.Atomiv.Core.Common.Files
{
    public class ExcelFile
    {
        public ExcelFile(List<ExcelSheet> sheets)
        {
            Sheets = sheets;
        }

        public List<ExcelSheet> Sheets { get; }
    }
}