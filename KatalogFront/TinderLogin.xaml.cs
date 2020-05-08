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
using System.Windows.Shapes;
using Tinder.API;
using Tinder.Db;

namespace KatalogFront
{
    /// <summary>
    /// Logika interakcji dla klasy TinderLogin.xaml
    /// </summary>
    public partial class TinderLogin : Window
    {
        public TinderLogin()
        {
            InitializeComponent();
        }

        private void LogTinder(object sender, RoutedEventArgs e)
        {
            string tinder_token_db = Tinder.Db.HL.GetSelfProfile().tinder_token;
            Tinder.API.OperationsHL.LoginTinderToken(tinder_token_db);
            Window1 wind = new Window1();
            wind.Show();
            this.Close();

        }
    }
}
