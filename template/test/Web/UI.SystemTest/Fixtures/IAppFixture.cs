using Optivem.Template.Web.UI.Client.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures
{
    public interface IAppFixture : IDisposable
    {
        IApp App { get; }
    }
}
