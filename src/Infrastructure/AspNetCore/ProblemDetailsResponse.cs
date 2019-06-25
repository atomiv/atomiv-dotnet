using Microsoft.AspNetCore.Mvc;
using Optivem.Framework.Core.Common.Http;

namespace Optivem.Framework.Infrastructure.AspNetCore
{
    public class ProblemDetailsResponse : ProblemDetails, IProblemDetails
    {
    }
}