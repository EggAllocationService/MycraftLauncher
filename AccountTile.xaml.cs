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
            
            if(!showButton)
            {
                loginButton.IsEnabled = false;
                loginButton.Visibility = Visibility.Hidden;
            } else
            {
                this.VerticalAlignment = VerticalAlignment.Top;
            }
        }
    }
}
