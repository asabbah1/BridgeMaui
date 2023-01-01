using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Helpers
{
    public static class Common
    {
        public static bool IsValidEmail(this string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
        public static bool IsValidDate(object Expression)
        {
            DateTime retYear;

            bool IsValidDate = DateTime.TryParse(Convert.ToString(Expression), out retYear);

            return IsValidDate;
        }
        public static bool AllStringPropertyValuesAreNonEmpty(this object myObject)
        {
            var allStringPropertyValues =
                from property in myObject.GetType().GetProperties()
                where property.PropertyType == typeof(string) && property.CanRead
                select (string)property.GetValue(myObject);

            return allStringPropertyValues.All(value => !string.IsNullOrEmpty(value));
        }

        public static async Task CleanCredentials()
        {
            await SecureStorage.SetAsync("Username", "");
            await SecureStorage.SetAsync("Password", "");
        }

        public static async Task Logout()
        {
            await SecureStorage.SetAsync("AccessToken", "");
            //await SecureStorage.SetAsync("Username", "");
            //await SecureStorage.SetAsync("Password", "");
            await SecureStorage.SetAsync("UseType", "");
            await SecureStorage.SetAsync("ExpireDate", "");

            (App.Current as App).MainPage = new AppShell();

            //await AppShell.Current.GoToAsync("//" + nameof(LoginView));
        }



        public static FlowDirection GetFlowDirection()
        {
            if (Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == "ar")
                return FlowDirection.RightToLeft;

            return FlowDirection.LeftToRight;
        }

        public static bool IsArabic()
        {
            if (Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName == "ar")
                return true;

            return false;
        }
    }
}
