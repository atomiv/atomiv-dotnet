using Microsoft.AspNetCore.Mvc;
using Atomiv.Core.Common.Http;

namespace Atomiv.Infrastructure.AspNetCore
{
    public class ProblemDetailsResponse : ProblemDetails, IProblemDetails
    {
    }
}