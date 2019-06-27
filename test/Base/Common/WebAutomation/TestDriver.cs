using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Core.Common.WebAutomation.Assertion;
using System;
using System.Collections.Generic;

namespace Optivem.Framework.Test.Common.WebAutomation
{
    public abstract class TestDriver<TDriver, 
        TElement, 
        TTextBox, 
        TCheckBox, 
        TComboBox, 
        TButton, 
        TRadioButtonGroup, 
        TCheckBoxGroup,
        TAssertableElement,
        TAssertableTextBox,
        TAssertableCheckBox,
        TAssertableComboBox,
        TAssertableButton,
        TAssertableRadioButtonGroup,
        TAssertableCheckBoxGroup> 
        : ITestDriver, IDisposable
        where TDriver : IDriver<TElement, 
            TTextBox, 
            TCheckBox, 
            TComboBox, 
            TButton, 
            TRadioButtonGroup, 
            TCheckBoxGroup>
        where TElement : IElement
        where TTextBox : ITextBox
        where TCheckBox : ICheckBox
        where TComboBox : IComboBox
        where TButton : IButton
        where TRadioButtonGroup : IRadioButtonGroup
        where TCheckBoxGroup : ICheckBoxGroup
        where TAssertableElement : IAssertableElement
        where TAssertableTextBox : IAssertableTextBox
        where TAssertableCheckBox : IAssertableCheckBox
        where TAssertableComboBox : IAssertableComboBox
        where TAssertableButton : IAssertableButton
        where TAssertableRadioButtonGroup : IAssertableRadioButtonGroup
        where TAssertableCheckBoxGroup : IAssertableCheckBoxGroup
    {
        public TestDriver(TDriver driver)
        {
            Driver = driver;
        }

        public string Url
        {
            get { return Driver.Url; }
            set { Driver.Url = value; }
        }

        public TDriver Driver { get; }

        public void Dispose()
        {
            Driver.Dispose();
        }

        public abstract TAssertableCheckBox FindCheckBox(FindType findType, string findBy);

        public abstract TAssertableElement FindElement(FindType findType, string findBy);

        public abstract List<TAssertableElement> FindElementCollection(FindType findType, string findBy);

        public abstract TAssertableCheckBoxGroup FindCheckBoxGroup(FindType findType, string findBy);

        public abstract TAssertableComboBox FindComboBox(FindType findType, string findBy);

        public abstract TAssertableComboBox FindComboBoxByClass(string className);

        public abstract TAssertableRadioButtonGroup FindRadioGroup(FindType findType, string findBy);

        public abstract TAssertableTextBox FindTextBox(FindType findType, string findBy);

        public abstract TAssertableTextBox FindTextBoxById(string id);

        public abstract TAssertableButton FindButton(FindType findType, string findBy);

        public abstract TAssertableButton FindButtonByClass(string type);

    }

}
