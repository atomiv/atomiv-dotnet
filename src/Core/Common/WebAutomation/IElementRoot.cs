namespace Atomiv.Core.Common.WebAutomation
{
    public interface IElementRoot<TElementRoot, TElement, TTextBox, TCheckBox, TComboBox, TButton, TRadioButton, TRadioButtonGroup, TCheckBoxGroup, TCompositeElement>
        : IElement, IFinder<TElementRoot, TElement, TTextBox, TCheckBox, TComboBox, TButton, TRadioButton, TRadioButtonGroup, TCheckBoxGroup, TCompositeElement>
        where TElementRoot : IElementRoot<TElementRoot, TElement, TTextBox, TCheckBox, TComboBox, TButton, TRadioButton, TRadioButtonGroup, TCheckBoxGroup, TCompositeElement>
        where TElement : IElement
        where TTextBox : ITextBox
        where TCheckBox : ICheckBox
        where TComboBox : IComboBox
        where TButton : IButton
        where TRadioButton : IRadioButton
        where TRadioButtonGroup : IRadioButtonGroup
        where TCheckBoxGroup : ICheckBoxGroup
        where TCompositeElement : ICompositeElement
    {
    }
}