using Avalonia.Web.Blazor;

namespace expAvaloniaLumos.Web;

public partial class App
{
    protected override void OnParametersSet()
    {
        base.OnParametersSet();

        WebAppBuilder.Configure<expAvaloniaLumos.App>()
            .SetupWithSingleViewLifetime();
    }
}