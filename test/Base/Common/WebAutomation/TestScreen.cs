namespace Optivem.Framework.Test.Common.WebAutomation
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
