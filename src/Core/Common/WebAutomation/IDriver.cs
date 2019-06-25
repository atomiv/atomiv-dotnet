using System;

namespace Optivem.Framework.Core.Common.WebAutomation
{
    // TODO: VC: Check <TElement, TTextBox, TCheckBox, TComboBox, TButton, TRadioGroup, TCheckBoxGroup>

    public interface IDriver<TElement, TTextBox, TCheckBox, TComboBox, TButton, TRadioGroup, TCheckBoxGroup> : IDisposable
        where TElement : IElement
        where TTextBox : ITextBox
        where TCheckBox : ICheckBox
        where TComboBox : IComboBox
        where TButton : IButton
        where TRadioGroup : IRadioButtonGroup
        where TCheckBoxGroup : ICheckBoxGroup
    {
        string Url { get; set; }

        TElement FindElement(FindType findType, string findBy);

        TTextBox FindTextBox(FindType findType, string findBy);

        TCheckBox FindCheckBox(FindType findType, string findBy);

        TComboBox FindComboBox(FindType findType, string findBy);

        TButton FindButton(FindType findType, string findBy);

        TRadioGroup FindRadioGroup(FindType findType, string findBy);

        TCheckBoxGroup FindCheckBoxGroup(FindType findType, string findBy);
    }

    public interface IDriver : IDriver<IElement, ITextBox, ICheckBox, IComboBox, IButton, IRadioButtonGroup, ICheckBoxGroup>
    {

    }


    // TODO: VC: DELETE
    /*

    IRadioGroup<T> FindRadioGroup<T>(FindType findType, string findBy, Dictionary<string, T> values);
    ICheckBoxGroup<T> FindCheckBoxGroup<T>(FindType findType, string findBy, Dictionary<string, T> values);
    IComboBox<T> FindComboBox<T>(FindType findType, string findBy, Dictionary<string, T> values);
    */


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