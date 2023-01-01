using Bridge.Helpers;
using Bridge.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Services
{
    public interface IAccountService
    {
        Task<bool> IsTokenValid();
        Task<LoginModel> LoginAsync(string username, string password);
    }

    public class AccountService : IAccountService
    {
        public async Task<LoginModel> LoginAsync(string username, string password)
        {
            var model = new LoginModel()
            {
                success = true
            };

            DateTime expireTime = DateTime.Now.AddSeconds(300);
            await SecureStorage.SetAsync("AccessToken", "test");
            await SecureStorage.SetAsync("Username", "test");
            await SecureStorage.SetAsync("Password", "test1234");
            await SecureStorage.SetAsync("UserType", "Pharmacist");
            await SecureStorage.SetAsync("ExpireDate", expireTime.ToString());
            Globals.UserType = "Pharmacist";

            return model;
        }

        public async Task<bool> IsTokenValid()
        {

            return await Task.FromResult(true);

        }
    }
}
