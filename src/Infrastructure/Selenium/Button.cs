using OpenQA.Selenium;
using Atomiv.Core.Common.WebAutomation;
using System;
using System.Threading;

namespace Atomiv.Infrastructure.Selenium
{
    public class Button : Element, IButton
    {
        public Button(IWebElement element)
            : base(element)
        {
        }

        public void Click()
        {
            // Retry logic to handle stale elements and timing issues
            int maxRetries = 3;
            for (int i = 0; i < maxRetries; i++)
            {
                try
                {
                    // Ensure element is displayed and enabled
                    if (!WebElement.Displayed)
                    {
                        Thread.Sleep(500);
                        continue;
                    }

                    if (!WebElement.Enabled)
                    {
                        Thread.Sleep(500);
                        continue;
                    }

                    WebElement.Click();
                    return;
                }
                catch (StaleElementReferenceException)
                {
                    if (i == maxRetries - 1) throw;
                    Thread.Sleep(500);
                }
                catch (InvalidElementStateException)
                {
                    if (i == maxRetries - 1) throw;
                    Thread.Sleep(500);
                }
            }
        }
    }
}