using Optivem.Core.Common.WebAutomation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Test.Common.WebAutomation
{
    public interface ITestDriver
    {
        string Url { get; set; }

        ITestTextBox FindTextBox(FindType findType, string findBy);

        ICheckBox FindCheckBox(FindType findType, string findBy);

        IRadioGroup<T> FindRadioGroup<T>(FindType findType, string findBy, Dictionary<string, T> values);

        ICheckBoxGroup<T> FindCheckBoxGroup<T>(FindType findType, string findBy, Dictionary<string, T> values);

        IComboBox<T> FindComboBox<T>(FindType findType, string findBy, Dictionary<string, T> values);
    }
}
