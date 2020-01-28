using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Optivem.Atomiv.Web.AspNetCore
{
    public class ValidationProblemDetails : ProblemDetails
    {
        public List<ValidationError> ValidationErrors { get; set; }
    }
}