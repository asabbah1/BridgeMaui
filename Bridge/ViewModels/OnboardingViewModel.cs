using Bridge.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.ViewModels
{
    [INotifyPropertyChanged]
    public partial class OnboardingViewModel : BaseViewModel
    {
        public Command GoToLoginCommand { get; }
        public Command GoToRegisterCommand { get; }

        public OnboardingViewModel()
        {
            GoToLoginCommand = new Command(GoToLogin);
            GoToRegisterCommand = new Command(GoToRegister);
        }

        void GoToLogin()
        {
            AppShell.Current.GoToAsync(nameof(LoginView));
        }

        void GoToRegister()
        {
        }

        public override async Task Initialize()
        {
            if(!StorageHelper.IsFirstTime())
                await AppShell.Current.GoToAsync("//" + nameof(LoginView));

        }

        public override Task Stop()
        {
            return Task.CompletedTask;
        }
    }
}
