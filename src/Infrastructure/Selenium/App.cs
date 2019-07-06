namespace Optivem.Framework.Infrastructure.Selenium
{
    public abstract class App<THomePage> : PageObject<Driver> 
        where THomePage : Page
    {
        public App(Driver finder) : base(finder)
        {
        }
    }
}
