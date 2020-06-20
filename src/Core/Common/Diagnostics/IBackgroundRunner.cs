using System.Threading.Tasks;

namespace Atomiv.Core.Common.Diagnostics
{
    public interface IBackgroundRunner
    {
        Task RunAsync();
    }
}