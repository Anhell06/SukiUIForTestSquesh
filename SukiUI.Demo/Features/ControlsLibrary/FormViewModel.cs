﻿using Avalonia.Layout;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.ComponentModel;
#pragma warning disable CS0657 // Not a valid attribute location for this declaration

namespace SukiUI.Demo.Features.ControlsLibrary
{
    /// <summary>
    /// A demonstration of a Form ViewModel.
    /// The `property:` part is to target the property generated by CommunityToolkits sourcegen.
    /// </summary>
    public partial class FormViewModel : ObservableObject
    {
        [ObservableProperty] [property: Category("Category 1"), DisplayName("Nullable name")]
        private string? _nullableName = null;

        [ObservableProperty] [property: Category("Category 1"), DisplayName("Nullable description")]
        private string? _nullableDescription = null;

        [ObservableProperty] [property: Category("Category 1"), DisplayName("Nullable boolean")]
        private bool? _nullableBoolean = null;

        [ObservableProperty] [property: Category("Category 1"), DisplayName("Nullable dateTime")]
        private DateTime? _nullableDateTime = null;

        [ObservableProperty] [property: Category("Category 1"), DisplayName("Nullable dateTimeOffset")]
        private DateTimeOffset? _nullableDateTimeOffset = null;

        [ObservableProperty] [property: Category("Nullable numbers"), DisplayName("Nullable integer")]
        private int? _nullableInteger = null;

        [ObservableProperty] [property: Category("Nullable numbers"), DisplayName("Nullable long")]
        private long? _nullableLong = null;

        [ObservableProperty] [property: Category("Nullable numbers"), DisplayName("Nullable decimal")]
        private decimal? _nullableDecimal = null;

        [ObservableProperty] [property: Category("Nullable numbers"), DisplayName("Nullable float")]
        private float? _nullableFloat = null;

        [ObservableProperty] [property: Category("Nullable numbers"), DisplayName("Nullable double")]
        private double? _nullableDouble = null;

        [ObservableProperty] [property: Category("Category 2"), DisplayName("Name")]
        private string _name = string.Empty;

        [ObservableProperty] [property: Category("Category 2"), DisplayName("Description")]
        private string _description = string.Empty;

        [ObservableProperty] [property: Category("Numbers"), DisplayName("Integer")]
        private int _integer;

        [ObservableProperty] [property: Category("Numbers"), DisplayName("Decimal")]
        private decimal _decimal;

        [ObservableProperty] [property: Category("Category 2"), DisplayName("Boolean")]
        private bool _boolean;

        [ObservableProperty] [property: Category("Category 2"), DisplayName("DateTime")]
        private DateTime _dateTime = DateTime.MinValue;

        [ObservableProperty] [property: Category("Category 2"), DisplayName("DateTimeOffset")]
        private DateTimeOffset _dateTimeOffset = DateTimeOffset.MinValue;

        [ObservableProperty] [property: Category("Category 2"), DisplayName("Child form")]
        private ChildFormViewModel _childForm = new ChildFormViewModel();

        [ObservableProperty] [property: Category("Category 2"), DisplayName("Orientation")]
        private Orientation _orientation;
    }

    public partial class ChildFormViewModel : ObservableObject
    {
        [ObservableProperty] [property: Category("Text"), DisplayName("Name")]
        private string _name = string.Empty;

        [ObservableProperty] [property: Category("Text"), DisplayName("Description")]
        private string _description = string.Empty;

        [ObservableProperty] [property: Category("Numbers"), DisplayName("Integer")]
        private int _integer;

        [ObservableProperty] [property: Category("Numbers"), DisplayName("Decimal")]
        private decimal _decimal;

        [ObservableProperty] [property: Category("Misc"), DisplayName("Boolean")]
        private bool _boolean;

        [ObservableProperty] [property: Category("Misc"), DisplayName("DateTimeOffset")]
        private DateTimeOffset _dateTimeOffset = DateTimeOffset.MinValue;
    }
}

#pragma warning enable CS0657 // Not a valid attribute location for this declaration