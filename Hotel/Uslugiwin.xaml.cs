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
using System.Collections.ObjectModel;

namespace Hotel
{
    /// <summary>
    /// Interaction logic for Uslugiwin.xaml
    /// </summary>
    public partial class Uslugiwin : Window
    {
      //  public ObservableCollection<Uslugi> UslugiList { get; set; } = new ObservableCollection<Uslugi>();
        public void refresh()
        {
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
        public Uslugiwin()
        {
            
            InitializeComponent();



            refresh();
            /*string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select * from Uslugi";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Uslugi");
                sda.Fill(dt);
                grdUslugi.ItemsSource = dt.DefaultView;
            }*/
            //grdUslugi.ItemsSource = UslugiList;
        }

        private void GoToDodajUsluge_Click(object sender, RoutedEventArgs e)
        {
            
            DodajUslugewin dodajUslugewin= new DodajUslugewin();
            dodajUslugewin.ShowDialog();
            refresh();

        }
        
    }
}
