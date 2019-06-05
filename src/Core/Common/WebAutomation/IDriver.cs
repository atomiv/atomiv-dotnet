using System;
using System.Collections.Generic;

namespace Optivem.Core.Common.WebAutomation
{
    public interface IDriver : IDisposable
    {
        string Url { get; set; }

        ITextBox FindTextBox(FindType findType, string findBy);

        ICheckBox FindCheckBox(FindType findType, string findBy);

        IRadioGroup FindRadioGroup(FindType findType, string findBy);

        IRadioGroup<T> FindRadioGroup<T>(FindType findType, string findBy, Dictionary<string, T> values);

        ICheckBoxGroup FindCheckBoxGroup(FindType findType, string findBy);

        ICheckBoxGroup<T> FindCheckBoxGroup<T>(FindType findType, string findBy, Dictionary<string, T> values);

        IComboBox FindComboBox(FindType findType, string findBy);

        IComboBox<T> FindComboBox<T>(FindType findType, string findBy, Dictionary<string, T> values);
    }

    // TODO: VC: Maped radio group without mapping, e.g. when want to access raw strings, or perhaps ints, where there is no fixed range in advance

    /*
     *

        protected SeleniumCheckBoxGroup<T> FindCheckBoxGroup<T>(By by, Dictionary<string, T> map)
        {
            var elements = FindAll(by);
            return new SeleniumCheckBoxGroup<T>(elements, map);

            // TODO: VC: Maped radio group without mapping, e.g. when want to access raw strings, or perhaps ints, where there is no fixed range in advance
        }

        protected SeleniumComboBox<T> FindComboBox<T>(By by, Dictionary<string, T> map)
        {
            var element = FindSingle(by);
            return new SeleniumComboBox<T>(element, map);

            // TODO: VC: Maped radio group without mapping, e.g. when want to access raw strings, or perhaps ints, where there is no fixed range in advance
        }
     *
     */
}