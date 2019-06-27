namespace Optivem.Framework.Test.Common.WebAutomation
{
    public class TestPageObject<TTestDriver> where TTestDriver : ITestDriver
    {
        public TestPageObject(TTestDriver driver)
        {
            Driver = driver;
        }

        public TTestDriver Driver { get; private set; }
    }
}
