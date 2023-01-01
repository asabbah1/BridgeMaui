using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Helpers
{
    public class StorageHelper
    {
        public static async Task<string> GetAccessToken()
        {
            var token = await SecureStorage.GetAsync("AccessToken");

            if (string.IsNullOrEmpty(token))
                throw new Exception("Invalid Access Token");

            return token;
        }

        public static async Task<string> GetUsername()
        {
            var username = await SecureStorage.GetAsync("Username");

            if (string.IsNullOrEmpty(username))
                return "";

            return username;
        }

        public static async Task<string> GetPassword()
        {
            var password = await SecureStorage.GetAsync("Password");

            if (string.IsNullOrEmpty(password))
                return "";

            return password;
        }

        public static async Task<UserTypes> GetUserType()
        {
            var data = await SecureStorage.GetAsync("UserType");

            if (string.IsNullOrEmpty(data))
                throw new Exception("Invalid UserType");

            if (data == "Pharmacist")
                return UserTypes.Pharmacist;
            else if (data == "Promoters")
                return UserTypes.Promoters;

            return UserTypes.Unkown;
        }

        public static string GetLang()
        {
            var data = Preferences.Get("Lang", "en");

            return data;
        }


        public static async Task<bool> IsTokenExpired()
        {
            var date = await SecureStorage.GetAsync("ExpireDate");

            if (string.IsNullOrEmpty(date))
                throw new Exception("Invalid Date");

            return DateTime.Now > Convert.ToDateTime(date) ;
        }

        public static async Task<bool> IsTokenValid()
        {
            try
            {
                await GetAccessToken();

                return !(await IsTokenExpired());
            }
            catch
            {
                return false;
            }
        }

        public static async Task<bool> IsUserAndPassExists()
        {
            var username = await GetUsername();
            var password = await GetPassword();

            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                return true;

            return false;
        }

        public static bool IsFirstTime()
        {
            var data = Preferences.Get("FirstTimeApp", true);

            if(data)
            {
                Preferences.Set("FirstTimeApp", false);
            }

            return data;
        }


    }

    public enum UserTypes
    {
        Pharmacist,
        Promoters,
        Unkown = -99
    }
}
