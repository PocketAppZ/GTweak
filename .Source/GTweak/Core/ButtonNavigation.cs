﻿using System.Windows;
using System.Windows.Controls;

namespace GTweak.Core
{
    internal sealed class ButtonNavigation : RadioButton
    {
        static ButtonNavigation() => DefaultStyleKeyProperty.OverrideMetadata(typeof(ButtonNavigation), new FrameworkPropertyMetadata(typeof(ButtonNavigation)));
    }
}
