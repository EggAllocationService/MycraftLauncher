using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using MycraftLauncher.Authentication;

namespace MycraftLauncher
{
    /// <summary>
    /// Interaction logic for AccountTile.xaml
    /// </summary>
    public partial class AccountTile : UserControl
    {
        AuthenticationDatabaseItem item;
        bool _button = false;
        public bool LoginButtonVisible
        {
            get => _button;
            set
            {
                if (value)
                {
                    loginButton.IsEnabled = true;
                    loginButton.Visibility = Visibility.Visible;
                } else
                {
                    loginButton.IsEnabled = false;
                    loginButton.Visibility = Visibility.Hidden;
                }
            }
        }

        public AccountTile(AuthenticationDatabaseItem acc, bool showButton)
        {
            InitializeComponent();
            username.Content = acc.profiles.First().Value.displayName;
            email.Content = acc.username;
            //email.Content = acc.accessToken;
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri("https://crafatar.com/renders/head/" + acc.profiles.First().Key + "?overlay");
            bitmapImage.EndInit();
            avatar.Source = bitmapImage;
            item = acc;
            if(!showButton)
            {
                loginButton.IsEnabled = false;
                loginButton.Visibility = Visibility.Hidden;
            } else
            {
                this.VerticalAlignment = VerticalAlignment.Top;
            }
        }
        public AccountTile()
        {
            InitializeComponent();
        }


        public void SetDatabaseItem(AuthenticationDatabaseItem acc)
        {
            InitializeComponent();
            username.Content = acc.profiles.First().Value.displayName;
            email.Content = acc.username;
            //email.Content = acc.accessToken;
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri("https://crafatar.com/renders/head/" + acc.profiles.First().Key + "?overlay");
            bitmapImage.EndInit();
            avatar.Source = bitmapImage;
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            if (Config.GlobalConfig.instance.authItem != null)
            {
                return;
            }
            if (item == null)
            {
                return;
            }
            Config.GlobalConfig.instance.authItem = item;
            Config.GlobalConfig.Save();


            var _current = App.currentWindow;
            App.Current.MainWindow = new MainWindow();
            App.Current.MainWindow.Show();
            _current.Close();
            App.currentWindow = App.Current.MainWindow;
        }
    }
}
