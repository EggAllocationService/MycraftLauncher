using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MycraftLauncher.Authentication
{
    public class LauncherProfiles
    {
        public Dictionary<String, AuthenticationDatabaseItem> authenticationDatabase;

    }
    public class AuthenticationDatabaseItem
    {
        public string username;
        public string accessToken;
        public Dictionary<String, AuthenticationProfile> profiles;
        public void FixAccessToken()
        {
            string actualToken = accessToken.Split(".")[1] + "=";
  
            string json = Encoding.UTF8.GetString(Convert.FromBase64String(actualToken));
            var t = JsonConvert.DeserializeObject<JwtJson>(json);
            accessToken = t.yggt;
        }

        class JwtJson
        {
            public string yggt;
        }
    }
    public class AuthenticationProfile
    {
        public string displayName;
    }
}
