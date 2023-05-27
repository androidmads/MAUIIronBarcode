
using IronBarCode;

namespace MAUI_Barcode;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    private async void SelectBarcode(object sender, EventArgs e)
    {
        try
        {
            var images = await FilePicker.Default.PickAsync(new PickOptions
            {
                PickerTitle = "Pick Barcode/QR Code Image",
                FileTypes = FilePickerFileType.Images
            });
            var imageSource = images.FullPath.ToString();
            barcodeImage.Source = imageSource;
            var result = BarcodeReader.Read(imageSource, new BarcodeReaderOptions()
            {
                ExpectBarcodeTypes = BarcodeEncoding.QRCode
            }).First().Text;
            outputText.Text = result;
        }
        catch (Exception ex)
        {
            await DisplayAlert("Barcode Reader", ex + "", "Ok");
        }

    }

}

