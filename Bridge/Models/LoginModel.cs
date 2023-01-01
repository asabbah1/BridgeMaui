using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge.Models
{
    public class LoginSuccessModel
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string Usertype { get; set; }
    }
    public class LoginErrorModel
    {
        public string error { get; set; }
        public string error_description { get; set; }
    }
    public class LoginModel
    {
        public bool success { get; set; }
        public LoginSuccessModel data { get; set; }
        public LoginErrorModel error { get; set; }
    }
}
