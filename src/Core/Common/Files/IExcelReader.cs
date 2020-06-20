namespace Atomiv.Core.Common.Files
{
    public interface IExcelReader
    {
        ExcelFile Read(string path);
    }
}