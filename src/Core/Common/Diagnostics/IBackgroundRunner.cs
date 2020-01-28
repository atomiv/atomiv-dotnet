using System.Threading.Tasks;

namespace Optivem.Atomiv.Core.Common.Diagnostics
{
    public interface IBackgroundRunner
    {
        Task RunAsync();
    }
}