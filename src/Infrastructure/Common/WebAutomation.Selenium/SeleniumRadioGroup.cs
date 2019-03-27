using OpenQA.Selenium;
using Optivem.Platform.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Optivem.Platform.Infrastructure.Common.WebAutomation.Selenium
{
    public class SeleniumRadioGroup<T> : IRadioGroup<T>
    {
        private Dictionary<T, SeleniumRadio> _radios;

        public SeleniumRadioGroup(Dictionary<T, SeleniumRadio> radios)
        {
            _radios = radios;
        }

        public void Select(T key)
        {
            var radio = _radios[key];
            radio.Select();
        }

        public T GetSelected()
        {
            return _radios.Where(e => e.Value.Selected)
                .Select(e => e.Key)
                .SingleOrDefault();
        }

        public bool HasSelected()
        {
            var selected = GetSelected();
            return selected != null;
        }
    }
}
