using System;
using System.Collections.Generic;
using System.IO;

namespace MycraftLauncher.Launcher
{

    class Updater
    {
        public delegate void Status(string msg, float progress);

        public static bool Update(Version v, Status status)
        {

            var dataDir = Config.GlobalConfig.dataDir;
            var versionDir = Path.Combine(dataDir, v.assets);
           

            return false;
        }


    }
    public class Arguments
    {
        public IList<object> game { get; set; }
        public IList<object> jvm { get; set; }
    }

    public class AssetIndex
    {
        public string id { get; set; }
        public string sha1 { get; set; }
        public int size { get; set; }
        public int totalSize { get; set; }
        public string url { get; set; }
    }

    public class Client
    {
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }

    public class ClientMappings
    {
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }

    public class Server
    {
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }

    public class ServerMappings
    {
        public string sha1 { get; set; }
        public int size { get; set; }
        public string url { get; set; }
    }

    public class Downloads
    {
        public Client client { get; set; }
        public ClientMappings client_mappings { get; set; }
        public Server server { get; set; }
        public ServerMappings server_mappings { get; set; }
    }

    public class JavaVersion
    {
        public string component { get; set; }
        public int majorVersion { get; set; }
    }

    public class Os
    {
        public string name { get; set; }
    }

    public class Rule
    {
        public string action { get; set; }
        public Os os { get; set; }
    }

    public class Natives
    {
        public string osx { get; set; }
        public string linux { get; set; }
        public string windows { get; set; }
    }

    public class Extract
    {
        public IList<string> exclude { get; set; }
    }

    public class DownloadLocation
    {
        public string sha1;
        public int size;
        public string url;
    }

    public class Library
    {
        public Dictionary<String, DownloadLocation> downloads { get; set; }
        public string name { get; set; }
        public IList<Rule> rules { get; set; }
        public Natives natives { get; set; }
        public Extract extract { get; set; }
    }

public class Version
    {
        public Arguments arguments { get; set; }
        public AssetIndex assetIndex { get; set; }
        public string assets { get; set; }
        public int complianceLevel { get; set; }
        public Downloads downloads { get; set; }
        public string id { get; set; }
        public JavaVersion javaVersion { get; set; }
        public IList<Library> libraries { get; set; }
        public string mainClass { get; set; }
        public int minimumLauncherVersion { get; set; }
        public DateTime releaseTime { get; set; }
        public DateTime time { get; set; }
        public string type { get; set; }
    }

}
