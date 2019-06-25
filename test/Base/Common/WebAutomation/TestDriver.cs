using Optivem.Framework.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;

namespace Optivem.Framework.Test.Common.WebAutomation
{
    public class TestDriver<TDriver> : IDisposable
        where TDriver : IDriver
    {
        private readonly TDriver _driver;

        public TestDriver(TDriver driver)
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

        public TestElement FindElement(FindType findType, string findBy)
        {
            var element = _driver.FindElement(findType, findBy);
            return new TestElement(element);
        }

        public List<TestElement> FindElementCollection(FindType findType, string findBy)
        {


            throw new NotImplementedException();
        }

        public TestCheckBoxGroup FindCheckBoxGroup(FindType findType, string findBy)
        {
            var checkBoxGroup = _driver.FindCheckBoxGroup(findType, findBy);
            return new TestCheckBoxGroup(checkBoxGroup);
        }



        public TestComboBox FindComboBox(FindType findType, string findBy)
        {
            var comboBox = _driver.FindComboBox(findType, findBy);
            return new TestComboBox(comboBox);
        }



        public TestComboBox FindComboBoxByClass(string className)
        {
            return FindComboBox(FindType.ClassName, className);
        }

        public TestRadioGroup FindRadioGroup(FindType findType, string findBy)
        {
            var radioGroup = _driver.FindRadioGroup(findType, findBy);
            return new TestRadioGroup(radioGroup);
        }




        public TestTextBox FindTextBox(FindType findType, string findBy)
        {
            var textBox = _driver.FindTextBox(findType, findBy);
            return new TestTextBox(textBox);
        }

        public TestTextBox FindTextBoxById(string id)
        {
            return FindTextBox(FindType.Id, id);
        }

        public TestButton FindButton(FindType findType, string findBy)
        {
            var button = _driver.FindButton(findType, findBy);
            return new TestButton(button);
        }
        public TestButton FindButtonByClass(string type)
        {
            return FindButton(FindType.ClassName, type);
        }



        // TODO: VC: DELETE this and the associated classes

        /*
         * 
         * 
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
         * 
         */

    }

    public class TestDriver : TestDriver<IDriver>
    {
        public TestDriver(IDriver driver) : base(driver)
        {
        }
    }
}
