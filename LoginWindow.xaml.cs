using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MycraftLauncher
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            if (Config.GlobalConfig.instance.authItem != null)
            {
               
                App.Current.MainWindow = new MainWindow();
                App.Current.MainWindow.Show();
                Close();
                App.currentWindow = App.Current.MainWindow;
            }

            string appData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string launcherJson = Path.Combine(appData, ".minecraft", "launcher_profiles.json");
            Authentication.LauncherProfiles profiles = Newtonsoft.Json.JsonConvert.DeserializeObject<Authentication.LauncherProfiles>(
                    File.ReadAllText(launcherJson)
                );
            
            foreach(Authentication.AuthenticationDatabaseItem i in profiles.authenticationDatabase.Values)
            {
                i.FixAccessToken();
                accountsList.Children.Add(new AccountTile(i,true));
            }
            progressBar.Visibility = Visibility.Hidden;
            App.currentWindow = this;
        }
    }
}
