using Optivem.Framework.Infrastructure.Selenium;
using System;

namespace Optivem.Framework.Test.Selenium
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

        protected abstract Driver CreateDriver();

        public void Dispose()
        {
            TestDriver.Dispose();
        }
    }
}
