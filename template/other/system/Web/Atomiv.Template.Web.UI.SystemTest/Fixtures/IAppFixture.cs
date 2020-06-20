using Atomiv.Template.Web.UI.Client.Interface;
using System;

namespace Atomiv.Template.Web.UI.SystemTest.Fixtures
{
    public interface IAppFixture : IDisposable
    {
        IApp App { get; }
    }
}