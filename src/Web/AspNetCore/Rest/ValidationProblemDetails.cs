using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Optivem.Platform.Web.AspNetCore.Rest
{
    public class ValidationProblemDetails : ProblemDetails
    {
        public List<ValidationError> ValidationErrors { get; set; }
    }
}
