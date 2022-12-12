using System.Linq;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Presenters;
using Avalonia.Input;
using Avalonia.Media;

namespace expAvaloniaLumos.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
        }

        private async void DoIt(object sender, TappedEventArgs e)
        {
            var chips = Enumerable
                .Range(0, 10)
                .Select(o =>
                {
                    var wrapPanel = new WrapPanel();
                    wrapPanel.Children.AddRange(Enumerable.Range(0, 10)
                        .Select(oo => new Label()
                            { Content = $"{o}{oo}", Margin = new Thickness(2), Background = Brushes.Red })
                        .ToArray());
                    return wrapPanel;
                });

            var stackPanel = new StackPanel();
            stackPanel.Children.AddRange(chips.ToArray());

            var contentPresenter = this.Get<ContentPresenter>("ContentPresenter2");
            contentPresenter.Content = stackPanel;
        }
    }
}