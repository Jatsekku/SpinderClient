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

namespace KatalogFront
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Sms(object sender, RoutedEventArgs e) // obsługa przyciśnięcia przycisku z ikonką SMS 
        {
            SMSLogin wind = new SMSLogin();         // stworzenie okna logowanie smsem
            wind.Show();                            // otworzenie okna logowania 
            this.Close();                           // zamknięcie okna startowego
        }

        private void Tinder(object sender, RoutedEventArgs e) // obsługa przyciśnięcia przycisku z ikonką Tinder
        {
            TinderLogin wind = new TinderLogin();  // stworzenie okna logowania przez tinder
            wind.Show();                           // otworzenie okna logowania  
            this.Close();                          // zamknięcie okna startowego 
        }
    }
}