using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Common.WebAutomation
{
    public interface IElementFinder<TElementRoot, TElement, TTextBox, TCheckBox, TComboBox, TButton, TRadioButton, TRadioButtonGroup, TCheckBoxGroup>
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
        TElement FindElement(IFindQuery query);

        IEnumerable<TElement> FindElements(IFindQuery query);

        TTextBox FindTextBox(IFindQuery query);

        IEnumerable<TTextBox> FindTextBoxes(IFindQuery query);

        TCheckBox FindCheckBox(IFindQuery query);

        IEnumerable<TCheckBox> FindCheckBoxes(IFindQuery query);

        TComboBox FindComboBox(IFindQuery query);

        IEnumerable<TComboBox> FindComboBoxes(IFindQuery query);

        TButton FindButton(IFindQuery query);

        IEnumerable<TButton> FindButtons(IFindQuery query);

        TRadioButton FindRadioButton(IFindQuery query);

        IEnumerable<TRadioButton> FindRadioButtons(IFindQuery query);

        TRadioButtonGroup FindRadioButtonGroup(IFindQuery query);

        TCheckBoxGroup FindCheckBoxGroup(IFindQuery query);
    }
}
