using Optivem.Framework.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public class CompositeElement : PageObject<ElementRoot>, ICompositeElement
    {
        public CompositeElement(ElementRoot finder) : base(finder)
        {
        }
    }
}
