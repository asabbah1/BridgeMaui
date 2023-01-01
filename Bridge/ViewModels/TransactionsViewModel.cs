using Bridge.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.ViewModels
{
    [INotifyPropertyChanged]
    public partial class TransactionsViewModel : BaseViewModel
    {

        public TransactionsViewModel()
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
