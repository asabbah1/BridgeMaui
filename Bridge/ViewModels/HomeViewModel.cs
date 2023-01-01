using Acr.UserDialogs;
using Bridge.Resources.Languages;
using Microsoft.Extensions.Localization;
using ZXing.Net.Maui;

namespace Bridge.ViewModels
{
    [INotifyPropertyChanged]
    public partial class HomeViewModel : BaseViewModel
    {
        private readonly IBarcodeService _barcodeService;
        private readonly IStringLocalizer<BridgeStrings> _localizer;


        public HomeViewModel(IBarcodeService barcodeService)
        {
            _barcodeService = barcodeService;
            _localizer = ServiceHelper.GetService<IStringLocalizer<BridgeStrings>>();
        }

      

        public override async Task Initialize()
        {
            var userType = await StorageHelper.GetUserType();
        }

        public override Task Stop()
        {
            return Task.CompletedTask;
        }

        public ICommand ScanCommand => new Command(async () => await Scan());

        async Task Scan()
        {
            var result = await _barcodeService.ShowBarcodeReader();

            if (result is not null)
            {
                var strQrCode = ((BarcodeResult)result).Value;

            }
        }

    }
}
