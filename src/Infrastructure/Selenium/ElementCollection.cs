using OpenQA.Selenium;
using Optivem.Core.Common.WebAutomation;
using System.Collections.ObjectModel;

namespace Optivem.Infrastructure.Selenium
{
    public class ElementCollection: IElement
    {
        public ElementCollection(ReadOnlyCollection<IWebElement> elements)
        {
            Elements = elements;
        }

        public ReadOnlyCollection<IWebElement> Elements { get; private set; }

        // TODO: VC: Check

        public bool Enabled => throw new System.NotImplementedException();

        public bool Visible => throw new System.NotImplementedException();
    }
}