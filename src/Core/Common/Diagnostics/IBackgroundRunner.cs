using System.Threading.Tasks;

namespace Optivem.Framework.Core.Common.Diagnostics
{
    public interface IBackgroundRunner
    {
        Task RunAsync();
    }
}
