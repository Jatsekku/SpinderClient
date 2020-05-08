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

namespace KatalogFront
{
    /// <summary>
    /// Logika interakcji dla klasy SMSLogin.xaml
    /// </summary>
    public partial class SMSLogin : Window
    {
        private string phone_number;
        private string otp_code;
        public SMSLogin()
        {
            InitializeComponent();
        }

        private void SendOTP(object sender, RoutedEventArgs e) // funkcja obsługująca przyciśnięcie przycisku "send OTP number"
        {
            phone_number = PhoneNum.Text;               // przypisanie phone_number tekstu z textboxa o nazwie PhoneNum
            if(phone_number.Length > 0)
                Tinder.API.OperationsHL.RequestOTP(phone_number);
            else
                MessageBox.Show("Please type valid phone number!");
        }

        private void Log(object sender, RoutedEventArgs e)    // funkcja obsługująca przysiśnięcie przycisku "log me in"
        {
            
            otp_code = OTP.Text;                       // przypisanie zmiennej otp_code pola Text z texboxa o nazwie OTP
            if (otp_code.Length == 6)
            {
                string tinder_token = Tinder.API.OperationsHL.LoginSMS(phone_number, otp_code);
                Tinder.Db.HL.UpdateSelfProfile(phone_number, tinder_token);
                Window1 wind = new Window1();                     // stworzenie obiektu klasy Window1
                wind.Show();                                     // otworzenie okna
                this.Close();                                    // zamknięcie bieżącego okna
            }
              
            else
                MessageBox.Show("Plese type valid six character long SMS code!");
                
           
        }
    }
}
