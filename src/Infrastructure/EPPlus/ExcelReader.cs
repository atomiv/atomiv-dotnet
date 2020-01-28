using OfficeOpenXml;
using Optivem.Atomiv.Core.Common.Files;
using System.Collections.Generic;
using System.IO;

namespace Optivem.Atomiv.Infrastructure.EPPlus
{
    public class ExcelReader : IExcelReader
    {
        public ExcelFile Read(string path)
        {
            var sheets = new List<ExcelSheet>();

            var fileInfo = new FileInfo(path);

            using (var package = new ExcelPackage(fileInfo))
            {
                var workBook = package.Workbook;

                foreach (var workSheet in workBook.Worksheets)
                {
                    var sheet = GetSheet(workSheet);
                    sheets.Add(sheet);
                }
            }

            return new ExcelFile(sheets);
        }

        private ExcelSheet GetSheet(ExcelWorksheet workSheet)
        {
            var name = workSheet.Name;

            var start = workSheet.Dimension.Start;
            var end = workSheet.Dimension.End;

            var rowLength = end.Row - start.Row;
            var colLength = end.Column - start.Column;

            var data = new object[rowLength, colLength];

            for (int row = start.Row; row <= end.Row; row++)
            {
                var i = start.Row - 1;

                for (int col = start.Column; col <= end.Column; col++)
                {
                    var j = start.Column - 1;

                    var value = workSheet.Cells[row, col];

                    data[i, j] = value;
                }
            }

            return new ExcelSheet(name, data);
        }
    }
}