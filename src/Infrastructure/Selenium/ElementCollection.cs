using OpenQA.Selenium;
using Optivem.Framework.Core.Common.WebAutomation;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Optivem.Framework.Infrastructure.Selenium
{
    // TODO: VC: Re-work this, because it's actually not an element...

    public class ElementCollection<TElement> where TElement : IElement
    {
        public ElementCollection(IEnumerable<TElement> elements)
        {
            Elements = elements;
        }

        public IEnumerable<TElement> Elements { get; private set; }
    }
}