using Optivem.Atomiv.Template.Web.UI.Client.Interface;
using System;

namespace Optivem.Atomiv.Template.Web.UI.SystemTest.Fixtures
{
    public interface IAppFixture : IDisposable
    {
        IApp App { get; }
    }
}