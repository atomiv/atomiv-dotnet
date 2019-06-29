using System;
using System.Collections.Generic;
using System.Text;

namespace Optivem.Framework.Core.Common.WebAutomation
{
    public interface IElementRoot<TElementRoot, TElement, TTextBox, TCheckBox, TComboBox, TButton, TRadioButton, TRadioButtonGroup, TCheckBoxGroup> : IElement, IElementFinder<TElementRoot, TElement, TTextBox, TCheckBox, TComboBox, TButton, TRadioButton, TRadioButtonGroup, TCheckBoxGroup>
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

    }
}
