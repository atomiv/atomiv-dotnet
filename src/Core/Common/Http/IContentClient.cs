using System.Threading.Tasks;

namespace Atomiv.Core.Common.Http
{
    public interface IContentClient
    {
        Task<string> GetAsync(string uri, HeaderDictionary headers = null);

        Task<string> PostAsync(string uri, string content, HeaderDictionary headers = null);

        Task<string> PutAsync(string uri, string content, HeaderDictionary headers = null);

        Task<string> DeleteAsync(string uri, HeaderDictionary headers = null);
    }
}