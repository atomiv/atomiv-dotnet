using Optivem.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;

namespace Optivem.Test.Common.WebAutomation
{
    public class TestDriver : IDisposable
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

        public void Dispose()
        {
            _driver.Dispose();
        }

        public TestCheckBox FindCheckBox(FindType findType, string findBy)
        {
            var checkBox = _driver.FindCheckBox(findType, findBy);
            return new TestCheckBox(checkBox);
        }

        public TestCheckBoxGroup FindCheckBoxGroup(FindType findType, string findBy)
        {
            var checkBoxGroup = _driver.FindCheckBoxGroup(findType, findBy);
            return new TestCheckBoxGroup(checkBoxGroup);
        }

        public TestCheckBoxGroup<T> FindCheckBoxGroup<T>(FindType findType, string findBy, Dictionary<string, T> values)
        {
            var checkBoxGroup = _driver.FindCheckBoxGroup(findType, findBy, values);
            return new TestCheckBoxGroup<T>(checkBoxGroup);
        }

        public TestComboBox FindComboBox(FindType findType, string findBy)
        {
            var comboBox = _driver.FindComboBox(findType, findBy);
            return new TestComboBox(comboBox);
        }

        public TestComboBox<T> FindComboBox<T>(FindType findType, string findBy, Dictionary<string, T> values)
        {
            var comboBox = _driver.FindComboBox(findType, findBy, values);
            return new TestComboBox<T>(comboBox);
        }

        public TestRadioGroup FindRadioGroup(FindType findType, string findBy)
        {
            var radioGroup = _driver.FindRadioGroup(findType, findBy);
            return new TestRadioGroup(radioGroup);
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
