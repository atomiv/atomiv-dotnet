using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public class ElementObject
    {
        public ElementObject(Element element)
        {
            Element = element;
        }

        public Element Element { get; }
    }
}
