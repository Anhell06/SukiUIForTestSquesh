﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using SukiUI.Extensions;

namespace SukiUI.Controls;

public partial class PercentProgressBar : UserControl
{
    public PercentProgressBar()
    {
        InitializeComponent();
        // Initialize controls in the constructor
        _progressBar = this.FindRequiredControl<ProgressBar>("barPercent") ?? throw new System.Exception();
        _textBlock = this.FindRequiredControl<TextBlock>("textPercent") ?? throw new System.Exception();
        _icon = this.FindRequiredControl<PathIcon>("iconPercent") ?? throw new System.Exception();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }

    // Declare private fields for controls
    private readonly ProgressBar _progressBar;

    private readonly TextBlock _textBlock;
    private readonly PathIcon _icon;

    private int _value;

    /// <summary>
    /// Gets the current value.
    /// </summary>
    public int Value
    {
        get => GetValue(ValueProperty);
        set
        {
            // Check if value is valid
            if (value is < 0 or > 100)
                return;

            // Set the value and raise the PropertyChanged event
            SetAndRaise(ValueProperty, ref _value, value);

            // Update the Value of the ProgressBar control
            _progressBar.Value = value;

            // Update the Text and Opacity of the TextBlock and MaterialIcon controls
            // based on the value of the Value property
            if (value != 100)
            {
                _textBlock.Text = $"{value} %";
            }
            else
            {
                _textBlock.Opacity = 0;
                _icon.Opacity = 1;
                _progressBar.Foreground = Brushes.ForestGreen;
            }
        }
    }

    /// <summary>
    /// Defines the <see cref="Value"/> property.
    /// </summary>
    public static readonly DirectProperty<PercentProgressBar, int> ValueProperty =
        AvaloniaProperty.RegisterDirect<PercentProgressBar, int>(
            nameof(Value),
            o => o.Value,
            (o, v) => o.Value = v,
            defaultBindingMode: BindingMode.TwoWay,
            enableDataValidation: true);
}