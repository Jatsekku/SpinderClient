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
using Tinder.Models.Db;
using Tinder.API;

namespace KatalogFront
{
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            Tinder.Db.HL.Fill(Tinder.API.OperationsLL.GetRecommendations());
        }

        private void Button_Distance(object sender, RoutedEventArgs e) // obsługa przycisku search
        {
            // okno ma textbloki o nazwach BioKeyword , Dist , Name. Te textbloki mają pole Text, to pole przechowuje aktualnego stringa wpisanego przez użytkownika

           
            int distnace_tmp = 0;
            if (Dist.Text.Length > 0)
                distnace_tmp = int.Parse(Dist.Text);

            var products_button = Tinder.Db.HL.GetSpecUserFromDb(Name.Text, BioKeyword.Text, distnace_tmp);           // przypisanie zmiennej products_button listy z drugiego przykładwoego konstruktora
            ListViewProducts.ItemsSource = products_button; // Podanie obiektowi ListViewProducts nowej listy produktów, nastąpi aktualizacja 
        }
    }
};
