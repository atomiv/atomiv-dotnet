namespace Optivem.Framework.Test.Common.WebAutomation
{
    public class TestPageObject
    {
        public TestPageObject(TestDriver driver)
        {
            Driver = driver;
        }

        public TestDriver Driver { get; private set; }
    }
}
