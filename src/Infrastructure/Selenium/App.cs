using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public abstract class App<THomePage> : PageObject 
        where THomePage : Page
    {
        public App(Driver driver) : base(driver)
        {
        }
    }
}
