using Optivem.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;

namespace Optivem.Test.Common.WebAutomation
{
    public class TestDriver
    {
        private readonly IDriver _driver;

        public TestDriver(IDriver driver)
        {
            _driver = driver;
        }

        public string Url
        {
            get { return _driver.Url; }
            set { _driver.Url = value; }
        }

        public TestCheckBox FindCheckBox(FindType findType, string findBy)
        {
            var checkBox = _driver.FindCheckBox(findType, findBy);
            return new TestCheckBox(checkBox);
        }

        public TestCheckBoxGroup<T> FindCheckBoxGroup<T>(FindType findType, string findBy, Dictionary<string, T> values)
        {
            var checkBoxGroup = _driver.FindCheckBoxGroup(findType, findBy, values);
            return new TestCheckBoxGroup<T>(checkBoxGroup);
        }

        public TestComboBox<T> FindComboBox<T>(FindType findType, string findBy, Dictionary<string, T> values)
        {
            var comboBox = _driver.FindComboBox(findType, findBy, values);
            return new TestComboBox<T>(comboBox);
        }

        public TestRadioGroup<T> FindRadioGroup<T>(FindType findType, string findBy, Dictionary<string, T> values)
        {
            var radioGroup = _driver.FindRadioGroup(findType, findBy, values);
            return new TestRadioGroup<T>(radioGroup);
        }

        public TestTextBox FindTextBox(FindType findType, string findBy)
        {
            var textBox = _driver.FindTextBox(findType, findBy);
            return new TestTextBox(textBox);
        }
    }
}
