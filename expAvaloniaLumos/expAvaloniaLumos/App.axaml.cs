using System.Net;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using expAvaloniaLumos.ViewModels;
using expAvaloniaLumos.Views;
using Lumos.Profiler.Client;

namespace expAvaloniaLumos
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            var profiler = new ProfilerClient();
            _ = profiler.Connect(IPAddress.Parse("127.0.0.1"), 15000);
            // _ = profiler.Connect(IPAddress.Parse("192.168.50.110"), 15000);
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainViewModel()
                };
            }
            else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
            {
                singleViewPlatform.MainView = new MainView
                {
                    DataContext = new MainViewModel()
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}