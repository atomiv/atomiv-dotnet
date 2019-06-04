using Optivem.Core.Common.WebAutomation;
using Optivem.Test.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Xunit.Selenium
{
    public class TestDriver : ITestDriver
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

        public ICheckBox FindCheckBox(FindType findType, string findBy)
        {
            var checkBox = _driver.FindCheckBox(findType, findBy);
            return checkBox;
        }

        public ICheckBoxGroup<T> FindCheckBoxGroup<T>(FindType findType, string findBy, Dictionary<string, T> values)
        {
            throw new NotImplementedException();
        }

        public IComboBox<T> FindComboBox<T>(FindType findType, string findBy, Dictionary<string, T> values)
        {
            throw new NotImplementedException();
        }

        public IRadioGroup<T> FindRadioGroup<T>(FindType findType, string findBy, Dictionary<string, T> values)
        {
            throw new NotImplementedException();
        }

        public ITestTextBox FindTextBox(FindType findType, string findBy)
        {
            var textBox = _driver.FindTextBox(findType, findBy);
            return new TestTextBox(textBox);
        }
    }
}
