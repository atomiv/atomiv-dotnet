using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Optivem.Framework.Web.AspNetCore.Rest
{
    public class ValidationProblemDetails : ProblemDetails
    {
        public List<ValidationError> ValidationErrors { get; set; }
    }
}
