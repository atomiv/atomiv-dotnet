namespace Optivem.Atomiv.Core.Common.Files
{
    public interface IExcelWriter
    {
        void Write(string path, ExcelFile file);
    }
}