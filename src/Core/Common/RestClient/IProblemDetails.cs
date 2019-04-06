using System.Collections.Generic;

namespace Optivem.Platform.Core.Common.RestClient
{
    public interface IProblemDetails
    {
        string Type { get; }

        string Title { get; }

        int? Status { get; }

        string Detail { get; }

        string Instance { get; }

        IDictionary<string, object> Extensions { get; }
    }
}
