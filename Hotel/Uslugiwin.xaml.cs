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
    /// Interaction logic for Uslugiwin.xaml
    /// </summary>
    public partial class Uslugiwin : Window
    {
        public Uslugiwin()
        {
            
            InitializeComponent();
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select * from Uslugi";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Uslugi");
                sda.Fill(dt);
                grdUslugi.ItemsSource = dt.DefaultView;
            }
        }

        private void GoToDodajUsluge_Click(object sender, RoutedEventArgs e)
        {
            
                DodajUslugewin dodajUslugewin= new DodajUslugewin();
            dodajUslugewin.ShowDialog();
            
        }
        private void UsunUsluge_Click(object sender, RoutedEventArgs e)
        {

            DodajUslugewin dodajUslugewin = new DodajUslugewin();
            dodajUslugewin.ShowDialog();

        }
    }
}
