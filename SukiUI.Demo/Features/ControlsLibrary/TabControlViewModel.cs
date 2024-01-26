using System.Linq;
using Avalonia.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using Material.Icons;

namespace SukiUI.Demo.Features.ControlsLibrary
{
    public class TabControlViewModel : DemoPageBase
    {
        public AvaloniaList<TabViewModel> Tabs { get; } = [];
        
        public TabControlViewModel() : base("Tabs", MaterialIconKind.Tab)
        {
            Tabs.AddRange(Enumerable.Range(1, 5).Select(x => new TabViewModel(x)));
        }
    }

    public class TabViewModel(int index) : ObservableObject
    {
        public string Header { get; } = $"Tab {index}";
        public string Content { get; } = $"Tab {index} Content.";
    }
}