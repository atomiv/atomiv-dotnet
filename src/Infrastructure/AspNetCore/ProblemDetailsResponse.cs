using Microsoft.AspNetCore.Mvc;
using Optivem.Atomiv.Core.Common.Http;

namespace Optivem.Atomiv.Infrastructure.AspNetCore
{
    public class ProblemDetailsResponse : ProblemDetails, IProblemDetails
    {
    }
}