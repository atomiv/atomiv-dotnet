using Optivem.Framework.Core.Common.WebAutomation;
using System.Collections.Generic;
using System.Linq;

namespace Optivem.Framework.Infrastructure.Selenium
{
    // TODO: VC: CONTINUE


    public class RadioButtonGroup : ElementCollection<RadioButton>, IRadioButtonGroup
    {
        public RadioButtonGroup(IEnumerable<RadioButton> elements) 
            : base(elements)
        {
        }

        public int Count
        {
            get
            {
                return Elements.Count();
            }
        }

        public string ReadSelectedValue()
        {
            var element = Elements.SingleOrDefault(e => e.IsSelected);

            if (element == null)
            {
                return null;
            }

            return element.Value;
        }

        public string ReadValue(int index)
        {
            var element = Elements.ElementAt(index);
            return element.Value;
        }

        public bool HasSelected()
        {
            var element = Elements.SingleOrDefault(e => e.IsSelected);
            return element != null;
        }

        public void SelectValue(string key)
        {
            var element = Elements.Single(e => e.Value == key);
            element.Select();
        }
    }
}