using Microsoft.AspNetCore.Mvc;
using Optivem.Platform.Core.Common.RestClient;
using System.Collections.Generic;

namespace Optivem.Platform.Infrastructure.Common.RestClient.Default
{
    internal class ProblemDetailsWrapper : IProblemDetails
    {
        private readonly ProblemDetails _problemDetails;

        public ProblemDetailsWrapper(ProblemDetails problemDetails)
        {
            _problemDetails = problemDetails;
        }

        public string Type => _problemDetails.Type;

        public string Title => _problemDetails.Title;

        public int? Status => _problemDetails.Status;

        public string Detail => _problemDetails.Detail;

        public string Instance => _problemDetails.Instance;

        public IDictionary<string, object> Extensions => _problemDetails.Extensions;
    }
}
