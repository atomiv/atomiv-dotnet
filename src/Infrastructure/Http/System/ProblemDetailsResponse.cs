using Microsoft.AspNetCore.Mvc;
using Optivem.Common.Http;

namespace Optivem.Infrastructure.Http.System
{
    public class ProblemDetailsResponse : ProblemDetails, IProblemDetails
    {
    }
}