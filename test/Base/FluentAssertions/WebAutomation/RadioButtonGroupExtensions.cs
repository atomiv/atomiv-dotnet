﻿using FluentAssertions;
using Optivem.Atomiv.Core.Common.WebAutomation;

namespace Optivem.Atomiv.Test.FluentAssertions.WebAutomation
{
    public static class RadioButtonGroupExtensions
    {
        public static void ShouldNotHaveSelection(IRadioButtonGroup radioButtonGroup)
        {
            radioButtonGroup.HasSelected().Should().BeFalse();
        }

        public static void ShouldHaveSelectedValue(IRadioButtonGroup radioButtonGroup, string key)
        {
            var selected = radioButtonGroup.ReadSelectedValue();
            selected.Should().Be(key);
        }
    }
}