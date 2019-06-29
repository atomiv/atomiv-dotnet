using Optivem.Framework.Core.Common.WebAutomation;

namespace Optivem.Framework.Infrastructure.Selenium
{
    public class PageObject<TFinder> 
        where TFinder : IFinder<ElementRoot, Element, TextBox, CheckBox, ComboBox, Button, RadioButton, RadioButtonGroup, CheckBoxGroup, CompositeElement>
    {
        public PageObject(TFinder finder)
        {
            Finder = finder;
        }

        public TFinder Finder { get; }
    }
}
