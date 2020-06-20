using Microsoft.AspNetCore.Mvc;

namespace Atomiv.Web.AspNetCore
{
    public interface IActionContextProblemDetailsFactory<TProblemDetails> where TProblemDetails : ProblemDetails
    {
        TProblemDetails Create(ActionContext actionContext);
    }
}