using Bridge.Views;
using CommunityToolkit.Maui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Services
{
    public interface IBarcodeService
    {
        Task<object> ShowBarcodeReader();
    }

    public class BarcodeService : IBarcodeService
    {
        public Task<object> ShowBarcodeReader()
        {
            return Application.Current.MainPage.ShowPopupAsync(new BarcodeReaderPopup());
        }
    }
}
