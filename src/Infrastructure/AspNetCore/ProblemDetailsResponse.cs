using Microsoft.AspNetCore.Mvc;
using Optivem.Core.Common.Http;

namespace Optivem.Infrastructure.AspNetCore
{
    public class ProblemDetailsResponse : ProblemDetails, IProblemDetails
    {
    }
}