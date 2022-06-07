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
    /// Interaction logic for Pracownicywin.xaml
    /// </summary>
    public partial class Pracownicywin : Window
    {
        public void refresh()
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select * from Pracownicy";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pracownicy");
                sda.Fill(dt);
                grdPracownicy.ItemsSource = dt.DefaultView;
            }
        }
        public Pracownicywin()
        {
            InitializeComponent();
            refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            

                DodajPracownikawin dodajPracownikawin = new DodajPracownikawin();
                dodajPracownikawin.ShowDialog();
                refresh();

            
        }
    }
}
