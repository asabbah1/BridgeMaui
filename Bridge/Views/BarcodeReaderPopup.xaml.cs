using CommunityToolkit.Maui.Views;
using ZXing.Net.Maui;
using ZXing.Net.Maui.Controls;

namespace Bridge.Views;

public partial class BarcodeReaderPopup : Popup
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility", Justification = "<Pending>")]
    public BarcodeReaderPopup()
	{
		InitializeComponent();

        barcodeView.Options = new BarcodeReaderOptions
        {
            Formats = BarcodeFormats.All,
            AutoRotate = true,
            Multiple = true  
        };
    }

	private void barcodeView_BarcodesDetected(object sender, ZXing.Net.Maui.BarcodeDetectionEventArgs e)
	{
        var first = e.Results?.FirstOrDefault();
        if (first is not null)
        {

            //Vibration.Default.Vibrate(TimeSpan.FromSeconds(0.05));
            Dispatcher.DispatchAsync(() =>
            {
                Close(first);
            });
            
        }
    }
}