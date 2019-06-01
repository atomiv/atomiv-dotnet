using Microsoft.AspNetCore.Mvc;
using Optivem.Common.Http;

namespace Optivem.Infrastructure.AspNetCore
{
    public class ProblemDetailsResponse : ProblemDetails, IProblemDetails
    {
    }
}