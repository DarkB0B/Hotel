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
using System.Data.Entity;
using System.Configuration;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
namespace Hotel
{
    /// <summary>
    /// Interaction logic for Klienciwin.xaml
    /// </summary>
    public partial class Klienciwin : Window
    {
        public Klienciwin()
        {
            InitializeComponent();
        }

        private void WszyscyKlienci_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select distinct k.IdKlienta as 'Id Klienta', k.Imie as 'Imię Klienta', k.Nazwisko as 'Nazwisko Klienta', k.Pesel as 'PESEL Klienta' from Klienci k";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Klienci");
                sda.Fill(dt);
                grdKlienci.ItemsSource = dt.DefaultView;
                Klienci_L.Content = "Wszyscy Klienci";
            }
        }
        private void AktualniKlienci_Click(object sender, RoutedEventArgs e)
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select k.IdKlienta as 'Id Klienta', k.Imie as 'Imię Klienta', k.Nazwisko as 'Nazwisko Klienta', k.Pesel as 'PESEL Klienta', p.DataPrzyjazdu as 'Data Przyjazdu', p.DataWyjazdu as 'Data Wyjazdu' from Klienci k inner join Pobyty p on k.IdKlienta = p.IdKlienta where p.DataPrzyjazdu < GETDATE() and DataWyjazdu > GETDATE()";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Klienci");
                sda.Fill(dt);
                grdKlienci.ItemsSource = dt.DefaultView;
                Klienci_L.Content = "Aktualni Klienci";
            }
        }
    }
}
