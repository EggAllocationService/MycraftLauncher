using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MycraftLauncher
{
    class Startup
    {
        [STAThread]
        public static void Main()
        {
            Config.GlobalConfig.Load();
            App app = new App();
            app.ShutdownMode = ShutdownMode.OnLastWindowClose;
            app.InitializeComponent();
            app.Run();
            
        }
    }
}
