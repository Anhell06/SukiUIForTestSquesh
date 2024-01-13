﻿using System.ComponentModel;
using System.Reflection;

namespace SukiUI.Controls
{
    public sealed class IntegerViewModel : PropertyViewModelBase<int?>
    {
        public IntegerViewModel(INotifyPropertyChanged viewmodel, string displayName, PropertyInfo propertyInfo)
            : base(viewmodel, displayName, propertyInfo)
        {
        }
    }
}