namespace Optivem.Framework.Infrastructure.Selenium
{
    public class PageObject
    {
        public PageObject(Driver driver)
        {
            Driver = driver;
        }

        public Driver Driver { get; }
    }
}
