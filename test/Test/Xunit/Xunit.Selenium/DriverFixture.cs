using Optivem.Core.Common.WebAutomation;
using Optivem.Test.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Xunit.Selenium
{
    public abstract class DriverFixture : IDisposable
    {
        public DriverFixture()
        {
            var driver = CreateDriver();
            TestDriver = new TestDriver(driver);

            // TODO: VC: Check if the top Driver should do the disposal, and construction...
        }

        public TestDriver TestDriver { get; }

        protected abstract IDriver CreateDriver();

        public void Dispose()
        {
            TestDriver.Dispose();
        }
    }
}
