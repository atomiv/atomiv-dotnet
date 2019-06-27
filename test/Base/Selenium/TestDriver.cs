using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Infrastructure.Selenium;
using Optivem.Framework.Test.Common.WebAutomation;
using System;
using System.Collections.Generic;

namespace Optivem.Framework.Test.Selenium
{
    public class TestDriver : TestDriver<Driver, 
        Element, 
        TextBox, 
        CheckBox, 
        ComboBox, 
        Button, 
        RadioButtonGroup, 
        CheckBoxGroup,
        TestElement,
        TestTextBox,
        TestCheckBox,
        TestComboBox,
        TestButton,
        TestRadioButtonGroup,
        TestCheckBoxGroup>
    {
        public TestDriver(Driver driver) : base(driver)
        {
        }
        public override TestCheckBox FindCheckBox(FindType findType, string findBy)
        {
            var checkBox = Driver.FindCheckBox(findType, findBy);
            return new TestCheckBox(checkBox);
        }

        public override TestElement FindElement(FindType findType, string findBy)
        {
            var element = Driver.FindElement(findType, findBy);
            return new TestElement(element);
        }

        public override List<TestElement> FindElementCollection(FindType findType, string findBy)
        {
            throw new NotImplementedException();
        }

        public override TestCheckBoxGroup FindCheckBoxGroup(FindType findType, string findBy)
        {
            var checkBoxGroup = Driver.FindCheckBoxGroup(findType, findBy);
            return new TestCheckBoxGroup(checkBoxGroup);
        }

        public override TestComboBox FindComboBox(FindType findType, string findBy)
        {
            var comboBox = Driver.FindComboBox(findType, findBy);
            return new TestComboBox(comboBox);
        }



        public override TestComboBox FindComboBoxByClass(string className)
        {
            return FindComboBox(FindType.ClassName, className);
        }

        public override TestRadioButtonGroup FindRadioGroup(FindType findType, string findBy)
        {
            var radioGroup = Driver.FindRadioGroup(findType, findBy);
            return new TestRadioButtonGroup(radioGroup);
        }

        public override TestTextBox FindTextBox(FindType findType, string findBy)
        {
            var textBox = Driver.FindTextBox(findType, findBy);
            return new TestTextBox(textBox);
        }

        public override TestTextBox FindTextBoxById(string id)
        {
            return FindTextBox(FindType.Id, id);
        }

        public override TestButton FindButton(FindType findType, string findBy)
        {
            var button = Driver.FindButton(findType, findBy);
            return new TestButton(button);
        }
        public override TestButton FindButtonByClass(string type)
        {
            return FindButton(FindType.ClassName, type);
        }
    }
}
