using Optivem.Framework.Core.Common.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace Optivem.Framework.Infrastructure.EPPlus.IntegrationTest
{
    public class ExcelWriterTest
    {
        [Fact]
        public void TestWrite()
        {
            var writer = new ExcelWriter();

            var path = GetTempFileName(".xlsx");

            var excelSheets = new List<ExcelSheet>();

            var numRows = 100;
            var numCols = 100;

            var data = new object[numRows, numCols];

            for(int i = 0; i < numRows; i++)
            {
                var rowPosition = i + 1;

                for(int j = 0; j < numCols; j++)
                {
                    var colPosition = j + 1;

                    data[i, j] = $"Cell {i}, {j}";
                }
            }

            var excelSheet1 = new ExcelSheet("my sheet", data);

            excelSheets.Add(excelSheet1);

            var excelFile = new ExcelFile(excelSheets);

            writer.Write(path, excelFile);

            var fileExists = File.Exists(path);

            Assert.True(fileExists);

            /*
            var reader = new ExcelReader();

            var results = reader.Read(path);
            */

            File.Delete(path);
        }

        // TODO: VC: Move to infrastructure for file paths, incl common extensions

        private string GetTempFileName(string extension)
        {
            var directoryPath = Path.GetTempPath();
            var fileName = Guid.NewGuid().ToString() + $".{extension}";

            return Path.Combine(directoryPath, fileName);
        }
    }
}
