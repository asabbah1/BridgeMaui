using Acr.UserDialogs;
using Bridge.Resources.Languages;
using CommunityToolkit.Maui.Core.Extensions;
using Microsoft.Extensions.Localization;
using System.ComponentModel.Design;
using System.Globalization;
using Thread = System.Threading.Thread;

namespace Bridge.ViewModels
{
    [INotifyPropertyChanged]
    public partial class ProfileViewModel : BaseViewModel
    {

        public ProfileViewModel()
        {
          
        }
        public override Task Initialize()
        {
            return Task.CompletedTask;
        }

        public override Task Stop()
        {
            return Task.CompletedTask;
        }

    }
}
