using Optivem.Template.Web.UI.Client.Interface;
using System;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures
{
    public interface IAppFixture : IDisposable
    {
        IApp App { get; }
    }
}
