using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Common.WebAutomation
{
    public interface IFinder<TElementRoot, TElement, TTextBox, TCheckBox, TComboBox, TButton, TRadioButton, TRadioButtonGroup, TCheckBoxGroup>
        where TElementRoot : IElementRoot<TElementRoot, TElement, TTextBox, TCheckBox, TComboBox, TButton, TRadioButton, TRadioButtonGroup, TCheckBoxGroup>
        where TElement : IElement
        where TTextBox : ITextBox
        where TCheckBox : ICheckBox
        where TComboBox : IComboBox
        where TButton : IButton
        where TRadioButton : IRadioButton
        where TRadioButtonGroup : IRadioButtonGroup
        where TCheckBoxGroup : ICheckBoxGroup
    {
        TElement FindElement(IQuery query);

        IEnumerable<TElement> FindElements(IQuery query);

        TTextBox FindTextBox(IQuery query);

        IEnumerable<TTextBox> FindTextBoxes(IQuery query);

        TCheckBox FindCheckBox(IQuery query);

        IEnumerable<TCheckBox> FindCheckBoxes(IQuery query);

        TComboBox FindComboBox(IQuery query);

        IEnumerable<TComboBox> FindComboBoxes(IQuery query);

        TButton FindButton(IQuery query);

        IEnumerable<TButton> FindButtons(IQuery query);

        TRadioButton FindRadioButton(IQuery query);

        IEnumerable<TRadioButton> FindRadioButtons(IQuery query);

        TRadioButtonGroup FindRadioButtonGroup(IQuery query);

        TCheckBoxGroup FindCheckBoxGroup(IQuery query);

        IEnumerable<T> FindElements<T>(IQuery query, Func<TElementRoot, T> create);

        T FindElement<T>(IQuery query, Func<TElementRoot, T> create);
    }
}
