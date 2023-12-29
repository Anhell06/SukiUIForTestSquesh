using Avalonia;
using Avalonia.Controls.Notifications;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using SukiUI.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Styling;

namespace SukiTest
{
    
    public partial class MainWindow : SukiWindow
    {
        public WindowNotificationManager notificationManager;
   

        public MainWindow()
        {
            InitializeComponent();
#if DEBUG
            this.AttachDevTools();
#endif
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

        protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
        {
            base.OnApplyTemplate(e);
            if(notificationManager == null)
                notificationManager = new WindowNotificationManager(this);
        }
        
        private void ChangeTheme(object? sender, RoutedEventArgs e)
        {
            if (Application.Current is null) return;
            var current = Application.Current.RequestedThemeVariant;
            Application.Current.RequestedThemeVariant = current == ThemeVariant.Dark 
                ? ThemeVariant.Light 
                : ThemeVariant.Dark;
            
            SukiHost.ShowToast("Successfully Changed Theme", $"Changed Theme To {Application.Current.RequestedThemeVariant}", onClicked:
                () =>
                {
                    SukiHost.ShowToast("Success!", "You Closed A Toast By Clicking On It!");
                });
        }
        
        
    }
}