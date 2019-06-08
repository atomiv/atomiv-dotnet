﻿using Optivem.Infrastructure.Selenium.Test.Screens;
using Optivem.Test.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Infrastructure.Selenium.Test.App
{
    public class SauceDemoApp : TestScreen
    {
        public SauceDemoApp(TestDriver driver) 
            : base(driver)
        {
        }

        public SauceDemoLoginScreen OpenLoginScreen()
        {
            return SauceDemoLoginScreen.Open(Driver);
        }

        public SauceDemoLoginScreen LoginScreen => new SauceDemoLoginScreen(Driver);

        public SauceDemoInventoryScreen InventoryScreen => new SauceDemoInventoryScreen(Driver);
    }
}
