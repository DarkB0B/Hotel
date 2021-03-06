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
    /// Interaction logic for Pokoje.xaml
    /// </summary>
    public partial class Pokojewin : Window
    {
        public Pokojewin() //przy otwarciu okna uzupelnienie tabeli wszystkimi pokojami
        {
            InitializeComponent();
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select distinct p.IdPokoju as 'Nr Pokoju',t.Typ as 'Typ pokoju', c.CenaPokoju as 'Cena za noc'  from Pobyty m full join Pokoje p on p.IdPokoju = m.IdPokoju inner join TypPokoju t on t.IdTypu = p.IdTypu inner join CenaPokoju c on c.IdCenyPokoju = p.IdCenyPokoju";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pokoje");
                sda.Fill(dt);
                grdPokoje.ItemsSource = dt.DefaultView;
                Pokoje_L.Content = "Wszystkie Pokoje";
            }
        }

        private void ZajetePokoje_Click(object sender, RoutedEventArgs e)// uzupelnienie tabeli zajętymi pokojami
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select distinct p.IdPokoju as 'Nr Pokoju', t.Typ as 'Typ pokoju', c.CenaPokoju as 'Cena za noc', m.DataPrzyjazdu as 'Zajęty od', m.DataWyjazdu as 'Zajęty do'  from Pobyty m full join Pokoje p on p.IdPokoju = m.IdPokoju inner join TypPokoju t on t.IdTypu = p.IdTypu inner join CenaPokoju c on c.IdCenyPokoju = p.IdCenyPokoju where DataWyjazdu > GETDATE()";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pokoje");
                sda.Fill(dt);
                grdPokoje.ItemsSource = dt.DefaultView;
                Pokoje_L.Content = "Zajęte Pokoje";
            }
        }
        
        private void WolnePokoje_Click(object sender, RoutedEventArgs e)// uzupelnienie tabeli wolnymi pokojami
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select distinct p.IdPokoju as 'Nr Pokoju',t.Typ as 'Typ pokoju', c.CenaPokoju as 'Cena za noc'  from Pobyty m full join Pokoje p on p.IdPokoju = m.IdPokoju inner join TypPokoju t on t.IdTypu = p.IdTypu inner join CenaPokoju c on c.IdCenyPokoju = p.IdCenyPokoju  except select distinct p.IdPokoju as 'Nr Pokoju',t.Typ as 'Typ pokoju', c.CenaPokoju as 'Cena za noc'  from Pobyty m inner join Pokoje p on p.IdPokoju = m.IdPokoju inner join TypPokoju t on t.IdTypu = p.IdTypu inner join CenaPokoju c on c.IdCenyPokoju = p.IdCenyPokoju where DataWyjazdu > GETDATE()";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pokoje");
                sda.Fill(dt);
                grdPokoje.ItemsSource = dt.DefaultView;
                Pokoje_L.Content = "Wolne Pokoje";
            }
        }

        private void WszystkiePokoje_Click(object sender, RoutedEventArgs e)// uzupelnienie tabeli wszystkimi pokojami
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select distinct p.IdPokoju as 'Nr Pokoju',t.Typ as 'Typ pokoju', c.CenaPokoju as 'Cena za noc'  from Pobyty m full join Pokoje p on p.IdPokoju = m.IdPokoju inner join TypPokoju t on t.IdTypu = p.IdTypu inner join CenaPokoju c on c.IdCenyPokoju = p.IdCenyPokoju";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pokoje");
                sda.Fill(dt);
                grdPokoje.ItemsSource = dt.DefaultView;
                Pokoje_L.Content = "Wszystkie Pokoje";
            }
        }
    }
}
