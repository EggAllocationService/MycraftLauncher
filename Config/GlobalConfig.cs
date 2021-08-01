using MycraftLauncher.Authentication;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MycraftLauncher.Config
{
    public class GlobalConfig
    {
        public AuthenticationDatabaseItem authItem;




        #region save/load stuff
        public static GlobalConfig instance;
        public static string dataDir;
        public static void Load()
        {
            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            dataDir = Path.Combine(appData, ".mycraft");
            if (Directory.Exists(dataDir))
            {
                // folder already exists
                if (File.Exists(Path.Combine(dataDir, "config.json")))
                {
                    var contents = File.ReadAllText(Path.Combine(dataDir, "config.json"));
                    instance = JsonConvert.DeserializeObject<GlobalConfig>(contents);
                } else
                {
                    instance = new GlobalConfig();
                }
            } else
            {
                Directory.CreateDirectory(dataDir);
                instance = new GlobalConfig();
            }
        }
        public static void Save()
        {
            // .mycraft MUST exist at this point, so we have the go-ahead to just rip it
            var configFile = Path.Combine(dataDir, "config.json");
            var json = JsonConvert.SerializeObject(instance, Formatting.Indented);
            File.WriteAllText(configFile, json);
        }

    }
    #endregion
}
