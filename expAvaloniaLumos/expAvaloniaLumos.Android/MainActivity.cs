using Android.App;
using Android.Content.PM;
using Avalonia.Android;
using Avalonia;
using Android.Content;
using Android.OS;

namespace expAvaloniaLumos.Android
{
    [Activity(Label = "expAvaloniaLumos.Android", Theme = "@style/MyTheme.NoActionBar", Icon = "@drawable/icon",
        LaunchMode = LaunchMode.SingleInstance,
        ConfigurationChanges = ConfigChanges.Orientation | ConfigChanges.ScreenSize)]
    public class MainActivity : AvaloniaMainActivity
    {
    }
}