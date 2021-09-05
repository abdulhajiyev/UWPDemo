using System;
using Windows.Devices.Input;
using Windows.UI;
using Windows.UI.Input;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;


namespace UWPDemo
{
    public sealed partial class MainPage
    {
        public Random Random { get; set; } = new Random();

        public MainPage()
        {
            InitializeComponent();
        }

        private SolidColorBrush CreateColor()
        {

            var r = Convert.ToByte(Random.Next(0, 255));
            var g = Convert.ToByte(Random.Next(0, 255));
            var b = Convert.ToByte(Random.Next(0, 255));

            return new SolidColorBrush(Color.FromArgb(255, r, g, b));
        }

        private void Btn_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn) btn.Background = CreateColor();
        }

        private void Btn_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (e.Pointer.PointerDeviceType != PointerDeviceType.Mouse) return;
            var p = e.GetCurrentPoint((UIElement)sender);
            if (p.Properties.PointerUpdateKind == PointerUpdateKind.RightButtonPressed)
            {
                BtnGrid.Children.Remove(btn);
            }

            if (BtnGrid.Children.Count != 0) return;
            ApplicationView appView = ApplicationView.GetForCurrentView();
            appView.Title = "No Button";
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            ApplicationView appView = ApplicationView.GetForCurrentView();

            if (btn == null) return;
            btn.Background = CreateColor();
            if (btn.Content != null) appView.Title = btn.Content.ToString();
        }
    }
}
