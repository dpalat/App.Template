using System;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace App.Template.XForms.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ScanBarcodeView
    {
        private ZXingScannerView _zxing;
        private BoxView _focusLine;
        private bool _keepTimerEnable = true;

        public ScanBarcodeView()
        {
            InitializeComponent();
            InitializeScanView();
        }

        private void InitializeScanView()
        {
            _zxing = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            _zxing.OnScanResult += result =>
                Device.BeginInvokeOnMainThread(async () =>
                {
                    _keepTimerEnable = false;
                    _zxing.IsAnalyzing = false;
                    _zxing.IsScanning = false;

                    await Navigation.PopAsync();
                    await DisplayAlert("Scanned Barcode", result.Text, "OK");
                });

            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            grid.Children.Add(_zxing);
            grid.Children.Add(GetOverlay());

            _zxing.Options = new MobileBarcodeScanningOptions
            {
                PossibleFormats = Enum.GetValues(typeof(ZXing.BarcodeFormat)).Cast<ZXing.BarcodeFormat>().ToList()
            };
            _zxing.IsScanning = true;
            _zxing.IsAnalyzing = true;

            Device.StartTimer(TimeSpan.FromMilliseconds(500), () =>
            {
                _focusLine.IsVisible = !_focusLine.IsVisible;
                return _keepTimerEnable;
            });

            Content = grid;
        }

        private Grid GetOverlay()
        {
            var grid = new Grid
            {
                ColumnSpacing = 0,
                RowSpacing = 0,
                RowDefinitions =
                {
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(2, GridUnitType.Star)},
                    new RowDefinition {Height = new GridLength(1, GridUnitType.Star)}
                },
                ColumnDefinitions =
                {
                    new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
                }
            };

            grid.Children.Add(new BoxView
            {
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 1,
                BackgroundColor = Color.Black,
                Opacity = 0.7
            }, 0, 0);

            grid.Children.Add(new Image {Source = "barcode_scanner_focus.png", Aspect = Aspect.Fill}, 0, 1);
            _focusLine = new BoxView
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 1,
                BackgroundColor = Color.Red
            };
            grid.Children.Add(_focusLine, 0, 1);

            grid.Children.Add(new BoxView
            {
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                HeightRequest = 1,
                BackgroundColor = Color.Black,
                Opacity = 0.7
            }, 0, 2);

            return grid;
        }
    }
}