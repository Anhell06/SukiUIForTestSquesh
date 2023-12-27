using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Controls.Primitives;
using Avalonia.Layout;
using Avalonia.Media;
using Avalonia.Styling;

namespace SukiUI.Controls;

public class SukiWindow : Window
{
    protected override Type StyleKeyOverride => typeof(SukiWindow);
    
        public static readonly StyledProperty<HorizontalAlignment> TitleHorizontalAlignmentProperty =
        AvaloniaProperty.Register<SukiWindow, HorizontalAlignment>(nameof(TitleHorizontalAlignment),
            defaultValue: HorizontalAlignment.Left);

    public HorizontalAlignment TitleHorizontalAlignment
    {
        get => GetValue(TitleHorizontalAlignmentProperty);
        set => SetValue(TitleHorizontalAlignmentProperty, value);
    }

    public static readonly StyledProperty<double> TitleFontSizeProperty =
        AvaloniaProperty.Register<SukiWindow, double>(nameof(TitleFontSize), defaultValue: 13);

    public double TitleFontSize
    {
        get => GetValue(TitleFontSizeProperty);
        set => SetValue(TitleFontSizeProperty, value);
    }


    public static readonly StyledProperty<FontWeight> TitleFontWeightProperty =
        AvaloniaProperty.Register<SukiWindow, FontWeight>(nameof(TitleFontWeight),
            defaultValue: FontWeight.DemiBold);

    public FontWeight TitleFontWeight
    {
        get => GetValue(TitleFontWeightProperty);
        set => SetValue(TitleFontWeightProperty, value);
    }

    public static readonly StyledProperty<IBrush> LogoColorProperty =
        AvaloniaProperty.Register<SukiWindow, IBrush>(nameof(LogoColor), defaultValue: Brushes.DarkSlateBlue);

    public IBrush LogoColor
    {
        get => GetValue(LogoColorProperty);
        set => SetValue(LogoColorProperty, value);
    }

    public static readonly StyledProperty<Control> LogoContentProperty =
        AvaloniaProperty.Register<SukiWindow, Control>(nameof(LogoContent), defaultValue: new Border());

    public Control LogoContent
    {
        get => GetValue(LogoContentProperty);
        set => SetValue(LogoContentProperty, value);
    }

    public static readonly StyledProperty<bool> ShowBottomBorderProperty =
        AvaloniaProperty.Register<SukiWindow, bool>(nameof(ShowBottomBorder), defaultValue: true);

    public bool ShowBottomBorder
    {
        get => GetValue(ShowBottomBorderProperty);
        set => SetValue(ShowBottomBorderProperty, value);
    }

    public static readonly StyledProperty<bool> IsMinimizeButtonEnabledProperty =
        AvaloniaProperty.Register<SukiWindow, bool>(nameof(IsMinimizeButtonEnabled), defaultValue: true);

    public bool IsMinimizeButtonEnabled
    {
        get => GetValue(IsMinimizeButtonEnabledProperty);
        set => SetValue(IsMinimizeButtonEnabledProperty, value);
    }

    public static readonly StyledProperty<bool> IsMaximizeButtonEnabledProperty =
        AvaloniaProperty.Register<SukiWindow, bool>(nameof(IsMaximizeButtonEnabled), defaultValue: true);

    public bool IsMaximizeButtonEnabled
    {
        get => GetValue(IsMaximizeButtonEnabledProperty);
        set => SetValue(IsMaximizeButtonEnabledProperty, value);
    }

    public static readonly StyledProperty<bool> MenuVisibilityProperty =
        AvaloniaProperty.Register<SukiWindow, bool>(nameof(MenuVisibility), defaultValue: false);

    public bool MenuVisibility
    {
        get => GetValue(MenuVisibilityProperty);
        set => SetValue(MenuVisibilityProperty, value);
    }

    public static readonly StyledProperty<List<MenuItem>> MenuItemsProperty =
        AvaloniaProperty.Register<SukiWindow, List<MenuItem>>(nameof(MenuItems),
            defaultValue: new List<MenuItem>());

    public List<MenuItem> MenuItems
    {
        get => GetValue(MenuItemsProperty);
        set => SetValue(MenuItemsProperty, value);
    }
    
    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);
        
        // Apply a style only on windows to offset oversizing.
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            var maxStyle = new Style(
                x => x.OfType<Window>()
                    .Class("NakedWindow")
                    .PropertyEquals(WindowStateProperty, WindowState.Maximized)
                    .Template()
                    .OfType<ContentPresenter>()
                    .Name("PART_ContentPresenter"));
            maxStyle.Setters.Add(new Setter(PaddingProperty, new Thickness(8)));
            Application.Current!.Styles.Add(maxStyle);
        }
        
        if (e.NameScope.Find<Button>("PART_MaximizeButton") is { } maximize)
            maximize.Click += (_, _) =>
                WindowState = WindowState == WindowState.Maximized
                    ? WindowState.Normal
                    : WindowState.Maximized;
        ;
        if (e.NameScope.Find<Button>("PART_MinimizeButton") is { } minimize)
            minimize.Click += (_, _) => WindowState = WindowState.Minimized;
        
        if (e.NameScope.Find<Button>("PART_CloseButton") is { } close)
            close.Click += (_, _) => Close();
    }
}