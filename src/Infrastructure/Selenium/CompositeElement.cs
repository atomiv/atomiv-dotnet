using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public class CompositeElement : PageObject<ElementRoot>
    {
        public CompositeElement(ElementRoot finder) : base(finder)
        {
        }
    }
}
