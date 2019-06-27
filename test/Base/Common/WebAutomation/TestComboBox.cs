using FluentAssertions;
using Optivem.Framework.Core.Common.WebAutomation;
using Optivem.Framework.Core.Common.WebAutomation.Assertion;

namespace Optivem.Framework.Test.Common.WebAutomation
{
    public class TestComboBox<TComboBox> : TestElement<TComboBox>, IAssertableComboBox
        where TComboBox : IComboBox
    {
        public TestComboBox(TComboBox element)
            : base(element)
        {
        }

        public int Count => Element.Count;

        public void SelectByValue(string key)
        {
            Element.SelectByValue(key);
        }
        public void SelectByText(string text)
        {
            Element.SelectByText(text);
        }

        public string ReadSelectedValue()
        {
            return Element.ReadSelectedValue();
        }

        public string ReadValue(int index)
        {
            return Element.ReadValue(index);
        }

        public bool HasSelected()
        {
            return Element.HasSelected();
        }

        public void ShouldNotHaveSelection()
        {
            HasSelected().Should().BeFalse();
        }

        public void ShouldHaveSelectedValue(string key)
        {
            var selected = ReadSelectedValue();
            selected.Should().Be(key);
        }


    }


    // TODO: VC: DELETE

    /*
    public class TestComboBox<T> : TestComboBox, IComboBox<T>
    {
        private readonly IComboBox<T> _comboBox;

        public TestComboBox(IComboBox<T> comboBox)
            : base(comboBox)
        {
            _comboBox = comboBox;
        }

        public T ReadSelected()
        {
            return _comboBox.ReadSelected();
        }

        public T Read(int index)
        {
            return _comboBox.Read(index);
        }

        public void Select(T key)
        {
            _comboBox.Select(key);
        }
    }

    */
}
