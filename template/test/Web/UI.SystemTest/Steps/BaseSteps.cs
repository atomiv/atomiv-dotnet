using Optivem.Template.Web.UI.SystemTest.Fixtures;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Web.UI.SystemTest.Steps
{
    public class BaseSteps
    {
        public BaseSteps(IAppFixture fixture)
        {
            Fixture = fixture;
        }

        public IAppFixture Fixture { get; }
    }
}
