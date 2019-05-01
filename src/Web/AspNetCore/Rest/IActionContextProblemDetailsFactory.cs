using Microsoft.AspNetCore.Mvc;

namespace Optivem.Framework.Web.AspNetCore.Rest
{
    public interface IActionContextProblemDetailsFactory<TProblemDetails> where TProblemDetails : ProblemDetails
    {
        TProblemDetails Create(ActionContext actionContext);
    }
}
