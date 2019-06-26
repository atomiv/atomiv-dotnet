using FluentAssertions;
using OpenQA.Selenium;
using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Framework.Test.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Template.Web.UI.SystemTest.Fixtures.Pages
{
    public class SauceDemoInventoryPage : TestPageObject
    {
        private const string Url = "https://www.saucedemo.com/inventory.html";

        public SauceDemoInventoryPage(TestDriver driver)
            : base(driver)
        {
            Driver.Url.Should().Be(Url);
        }

        public TestComboBox ProductSort => Driver.FindComboBoxByClass("product_sort_container");

        // TODO: VC: Do later

        // public List<InventoryItem> InventoryItems => Driver.FindElementCollection(FindType.ClassName, "inventory_item");


        public static SauceDemoInventoryPage Open(TestDriver driver)
        {
            driver.Url = Url;
            return new SauceDemoInventoryPage(driver);
        }
    }

    // TODO: VC: Container element

    public class InventoryItem : Element
    {
        public InventoryItem(IWebElement element)
            : base(element)
        {
        }

        public string Name => WebElement.FindElement(By.ClassName("inventory_item_name")).Text;

        public string Description => WebElement.FindElement(By.ClassName("inventory_item_desc")).Text;

        public string Price => WebElement.FindElement(By.ClassName("inventory_item_price")).Text;

        // Sauce Labs Backpack

    }
}
