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
using System.Runtime;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Hotel
{
    /// <summary>
    /// Interaction logic for DodajPobytwin.xaml
    /// </summary>
    public partial class DodajPobytwin : Window
    {
        HotelDbEntities context = new HotelDbEntities();
        public DodajPobytwin()
        {
            InitializeComponent();

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int maxid = context.Pobyty.Max(x => x.IdPobytu);
            int idPobytu = maxid + 1; //utworzenie id o 1 większego niż największe id istniejące w bazie
           
            try
            {
                if (nrKlientaTextBox.Text.Length == 9)
                {
                    if (peselTextBox.Text.Length == 11)
                    { 
                        //utworzenie zmiennych na podstawie podanych danych
                        string nazwauslugi = uslugaComboBox.SelectedItem.ToString();
                        string sidpokoju = nrpokojuComboBox.SelectedItem.ToString();
                        int idpokoju = Convert.ToInt32(sidpokoju);
                        int idpracownika = idPracownikaComboBox.SelectedIndex;
                        var usluga = context.Uslugi.SingleOrDefault(item => item.Usluga == nazwauslugi);
                        
                        //przeszukanie bazy czy istnieje klient z podanym numerem pesel
                        List<string> kliencipesel = new List<string>();
                        foreach (var item in context.Klienci)
                        {
                            kliencipesel.Add(item.Pesel);
                            
                        }
                        if (kliencipesel.Contains(peselTextBox.Text)) // jeśli istnieje już klient z podanym nr pesel zamówienie jest do niego przypisywane
                        {
                            
                            var klient = context.Klienci.SingleOrDefault(item => item.Pesel == peselTextBox.Text);
                            
                            Pobyty pobyt = new Pobyty() { IdPobytu = idPobytu, DataPrzyjazdu = (DateTime)dataPrzyjazduDatePicker.SelectedDate, DataWyjazdu = (DateTime)dataWyjazduDatePicker.SelectedDate, IdPokoju = idpokoju, IdPracownika = idpracownika, IdKlienta = klient.IdKlienta, IdUslugi = usluga.IdUslugi };
                            context.Pobyty.Add(pobyt);
                            context.SaveChanges();

                            this.Close();
                        }
                        else // jeśli nie istnieje klient z podanym nr pesel tworzony jest nowy klient i przypisywana jest do niego rezerwacja
                        {
                            int maxid2 = context.Klienci.Max(x => x.IdKlienta);
                            int idklienta = maxid2 + 1; //utworzenie id o 1 większego niż największe id istniejące w bazie
                            int nrklienta = Convert.ToInt32(nrKlientaTextBox.Text);
                           
                            
                            Klienci klient = new Klienci() { IdKlienta = idklienta, Imie = imieTextBox.Text, Nazwisko = nazwiskoTextBox.Text, NrKlienta = Convert.ToString(nrklienta), Pesel = peselTextBox.Text };
                            context.Klienci.Add(klient);

                            context.SaveChanges();
                            Pobyty pobyt = new Pobyty() { IdPobytu = idPobytu, DataPrzyjazdu = (DateTime)dataPrzyjazduDatePicker.SelectedDate, DataWyjazdu = (DateTime)dataWyjazduDatePicker.SelectedDate, IdPokoju = idpokoju, IdPracownika = idpracownika, IdKlienta = klient.IdKlienta, IdUslugi = usluga.IdUslugi };
                            context.Pobyty.Add(pobyt);
                            context.SaveChanges();

                            this.Close();
                        }
                        
                        
                    }
                    else
                    {
                        MessageBox.Show("Błędny nr PESEL");
                    }
                }
                else
                {
                    MessageBox.Show("Błędny nr telefonu");
                }


            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }
        public void loadpokoje()
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
                
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataPrzyjazduDatePicker.SelectedDate = DateTime.Now; //ustawienie dat na kalendarzu
            dataWyjazduDatePicker.SelectedDate = DateTime.Now;
            List<string> uslugi = new List<string>();
            foreach (var item in context.Uslugi) //uzupełnienie comboboxa id usług
            {
                uslugi.Add(item.Usluga);
            }
            uslugaComboBox.ItemsSource = uslugi;
            List<int> pracownicy = new List<int>();
            foreach (var item in context.Pracownicy) //uzupełnienie comboboxa numerami pracowników
            {
                pracownicy.Add(item.IdPracownika);
            }
            idPracownikaComboBox.ItemsSource = pracownicy;


            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString)) //uzupełnienie comboboxa numerami pokoi
            {
                CmdString = "select distinct p.IdPokoju as 'Nr Pokoju',t.Typ as 'Typ pokoju', c.CenaPokoju as 'Cena za noc'  from Pobyty m full join Pokoje p on p.IdPokoju = m.IdPokoju inner join TypPokoju t on t.IdTypu = p.IdTypu inner join CenaPokoju c on c.IdCenyPokoju = p.IdCenyPokoju";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pokoje");
                sda.Fill(dt);
                List<string> wolnepokoje;
                wolnepokoje = (from DataRow row in dt.Rows select row["Nr Pokoju"].ToString()).ToList();
                nrpokojuComboBox.ItemsSource = wolnepokoje;
            }

            loadpokoje(); //uzupełnienie tabeli zarezerwowanych pokoi
            System.Windows.Data.CollectionViewSource pobytyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pobytyViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // pobytyViewSource.Source = [generic data source]
        }

        private void uslugaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        
        private void nrpokojuComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void idPracownikaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dataPrzyjazduDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void dataWyjazduDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

       
    }
}
