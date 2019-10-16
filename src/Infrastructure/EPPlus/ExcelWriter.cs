using OfficeOpenXml;
using Optivem.Framework.Core.Common.Files;
using System.IO;

namespace Optivem.Framework.Infrastructure.EPPlus
{
    public class ExcelWriter : IExcelWriter
    {
        public void Write(string path, ExcelFile file)
        {
            var fileInfo = new FileInfo(path);

            using (var package = new ExcelPackage())
            {
                var workBook = package.Workbook;

                foreach (var sheet in file.Sheets)
                {
                    AddSheet(workBook, sheet);
                }

                package.SaveAs(fileInfo);
            }
        }

        private void AddSheet(ExcelWorkbook book, ExcelSheet sheet)
        {
            var sheetName = sheet.Name;
            var workSheet = book.Worksheets.Add(sheetName);

            var data = sheet.Data;

            for (int i = 0; i < data.GetLength(0); i++)
            {
                var rowPosition = i + 1;

                for (int j = 0; j < data.GetLength(1); j++)
                {
                    var columnPosition = j + 1;

                    var value = data[i, j];

                    workSheet.Cells[rowPosition, columnPosition].Value = value;
                }
            }
        }
    }
}