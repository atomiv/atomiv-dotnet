using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace Atomiv.Web.AspNetCore
{
    public interface IExceptionHandler
    {
        public Task HandleAsync(HttpContext context, Exception exception);
    }
}
