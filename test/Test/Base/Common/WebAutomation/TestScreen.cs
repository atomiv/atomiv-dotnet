using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Common.WebAutomation
{
    public class TestScreen
    {
        public TestScreen(TestDriver driver)
        {
            Driver = driver;
        }

        public TestDriver Driver { get; private set; }
    }
}
