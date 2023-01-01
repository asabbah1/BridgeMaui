
using Acr.UserDialogs;
using Bridge.Resources.Languages;
using Microsoft.Extensions.Localization;
using Plugin.Fingerprint.Abstractions;

namespace Bridge.ViewModels
{
    [INotifyPropertyChanged]
    public partial class LoginViewModel : BaseViewModel
    {
        private readonly IAccountService _accountService;
        private readonly IFingerprint _fingerprint;
        private readonly IStringLocalizer<BridgeStrings> _localizer;

        public LoginViewModel(IAccountService accountService, IFingerprint fingerprint)
        {
            _accountService = accountService;
            _fingerprint = fingerprint;
            _localizer = ServiceHelper.GetService<IStringLocalizer<BridgeStrings>>();
        }

        [ObservableProperty]
        public string _username;
        [ObservableProperty]
        public string _password;

        [ObservableProperty]
        bool _isFingerVisible;



        public override async Task Initialize()
        {
            if (await _fingerprint.IsAvailableAsync())
            {
                IsFingerVisible = await StorageHelper.IsUserAndPassExists();
            }
        }

        public override Task Stop()
        {
            return Task.CompletedTask;
        }

        [RelayCommand]
        void GoToRegister()
        {
            
        }

        [RelayCommand]
        async Task Login()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                // Error
                await UserDialogs.Instance.AlertAsync(_localizer["ConnectionError"]);
                return;
            }

            await LoginAction(Username, Password);

        }

        [RelayCommand]
        public async Task LoginFinger()
        {
            if (Connectivity.Current.NetworkAccess != NetworkAccess.Internet)
            {
                // Error
                await UserDialogs.Instance.AlertAsync(_localizer["ConnectionError"]);
                return;
            }

            var request = new AuthenticationRequestConfiguration(_localizer["Login"], "Touch the fingerprint sensor zone below to verify your fingerprint");
            var result = await _fingerprint.AuthenticateAsync(request);

            if (result.Authenticated)
            {
                string username = await StorageHelper.GetUsername();
                string password = await StorageHelper.GetPassword();

                await LoginAction(username, password);



            }
            else
            {
                App.AlertSvc.ShowAlert("Error", "Not Valid Fingerprint");

            }
        }


        private async Task LoginAction(string username, string password)
        {
            try
            {
                UserDialogs.Instance.ShowLoading(_localizer["Loading"], MaskType.Gradient);
                var loginResult = await _accountService.LoginAsync(username, password);

                if (loginResult.success)
                {
                    await AppShell.Current.GoToAsync("//Home");

                }
                else
                {
                    App.AlertSvc.ShowAlert("Error", loginResult.error.error_description);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine(ex.Message);
                await UserDialogs.Instance.AlertAsync(_localizer["GeneralError"]);
            }
            finally
            {
                UserDialogs.Instance.HideLoading();
            }
        }

    
    }
}
