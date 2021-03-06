﻿using Atomiv.Core.Common.WebAutomation;
using System.Collections.Generic;

namespace Atomiv.Infrastructure.Selenium
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