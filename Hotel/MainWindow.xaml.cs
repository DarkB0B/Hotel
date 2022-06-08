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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HotelDbEntities context = new HotelDbEntities();
        public void refresh() //uzupełnienie tabeli aktualnymi pobytami
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select k.Imie as 'Imie Klienta', k.Nazwisko as 'Nazwisko Klienta', k.IdKlienta as 'Id Klienta',p.IdPokoju as 'Nr Pokoju',m.DataWyjazdu as 'Data Wyjazdu', u.Usluga 'Wykupiona Usuga', CenaPokoju*(DATEDIFF(day,DataPrzyjazdu,DataWyjazdu))+u.CenaUslugi as 'Cena Pobytu', m.IdPobytu as IdRezerwacji from Pobyty m  inner join pokoje p on m.IdPokoju = P.IdPokoju inner join CenaPokoju c on p.IdCenyPokoju = c.IdCenyPokoju inner join Klienci k on m.IdKlienta = k.IdKlienta inner join Uslugi u on m.IdUslugi = u.IdUslugi where  DataWyjazdu > GETDATE() and DataPrzyjazdu < GETDATE()";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pobyty");
                sda.Fill(dt);
                grdPobyty.ItemsSource = dt.DefaultView;
            }
            Pobyty.Content = "AktualnePobyty";
        }
        CollectionViewSource pobytyViewSource;
        public MainWindow()
        {
            InitializeComponent();
            pobytyViewSource = ((CollectionViewSource)(FindResource("pobytyViewSource")));
            //klienciViewSource = ((CollectionViewSource)(FindResource("klienciViewSource")));
            DataContext = this;
            refresh();

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            context.Pobyty.Load();
            // pobytyViewSource.Source = context.Pobyty.Local;
           
            // Load data by setting the CollectionViewSource.Source property:
            //klienciViewSource.Source = context.Klienci.Local;
            System.Windows.Data.CollectionViewSource pobytyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pobytyViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // pobytyViewSource.Source = [generic data source]
        }
        
        
        private void Rezerwacje_Click(object sender, RoutedEventArgs e) //uzupełnienie tabeli tylko rezerwacjami
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select k.Imie as 'Imie Klienta', k.Nazwisko as 'Nazwisko Klienta', k.IdKlienta as 'Id Klienta',p.IdPokoju as 'Nr Pokoju',m.DataWyjazdu as 'Data Wyjazdu', u.Usluga 'Wykupiona Usuga', CenaPokoju*(DATEDIFF(day,DataPrzyjazdu,DataWyjazdu))+u.CenaUslugi as 'Cena Pobytu', m.IdPobytu as IdRezerwacji from Pobyty m  inner join pokoje p on m.IdPokoju = P.IdPokoju inner join CenaPokoju c on p.IdCenyPokoju = c.IdCenyPokoju inner join Klienci k on m.IdKlienta = k.IdKlienta inner join Uslugi u on m.IdUslugi = u.IdUslugi where  DataWyjazdu > GETDATE() and DataPrzyjazdu > GETDATE()";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pobyty");
                sda.Fill(dt);
                grdPobyty.ItemsSource = dt.DefaultView;
            }
            Pobyty.Content = "Rezerwacje";
        }
        
        private void HistoriaPobytow_Click(object sender, RoutedEventArgs e) //uzupełnienie tabeli wszystkimi rezerwacjami aktualnymi i archiwalnymi
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select k.Imie as 'Imie Klienta', k.Nazwisko as 'Nazwisko Klienta', k.IdKlienta as 'Id Klienta',p.IdPokoju as 'Nr Pokoju',m.DataWyjazdu as 'Data Wyjazdu', u.Usluga 'Wykupiona Usuga', CenaPokoju*(DATEDIFF(day,DataPrzyjazdu,DataWyjazdu))+u.CenaUslugi as 'Cena Pobytu', m.IdPobytu as IdRezerwacji from Pobyty m  inner join pokoje p on m.IdPokoju = P.IdPokoju inner join CenaPokoju c on p.IdCenyPokoju = c.IdCenyPokoju inner join Klienci k on m.IdKlienta = k.IdKlienta inner join Uslugi u on m.IdUslugi = u.IdUslugi where DataPrzyjazdu < GETDATE()";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pobyty");
                sda.Fill(dt);
                grdPobyty.ItemsSource = dt.DefaultView;
            }
            Pobyty.Content = "HistoriaPobytow";
        }
        
        private void AktualnePobyty_Click(object sender, RoutedEventArgs e) //uzupełnienie tabeli aktualnymi rezerwacjami
        {
            string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
            string CmdString = string.Empty;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                CmdString = "select k.Imie as 'Imie Klienta', k.Nazwisko as 'Nazwisko Klienta', k.IdKlienta as 'Id Klienta',p.IdPokoju as 'Nr Pokoju',m.DataWyjazdu as 'Data Wyjazdu', u.Usluga 'Wykupiona Usuga', CenaPokoju*(DATEDIFF(day,DataPrzyjazdu,DataWyjazdu))+u.CenaUslugi as 'Cena Pobytu', m.IdPobytu as IdRezerwacji  from Pobyty m inner join pokoje p on m.IdPokoju = P.IdPokoju inner join CenaPokoju c on p.IdCenyPokoju = c.IdCenyPokoju inner join Klienci k on m.IdKlienta = k.IdKlienta inner join Uslugi u on m.IdUslugi = u.IdUslugi where  DataWyjazdu > GETDATE() and DataPrzyjazdu < GETDATE()";
                SqlCommand cmd = new SqlCommand(CmdString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable("Pobyty");
                sda.Fill(dt);              
                grdPobyty.ItemsSource = dt.DefaultView;
            }
            Pobyty.Content = "AktualnePobyty";
        }
        private void GoToPokoje_Click(object sender, RoutedEventArgs e) //otwarcie okna pokoi
        {
            Pokojewin pokojewin = new Pokojewin();
            pokojewin.ShowDialog();
        }
        private void GoToKlienci_Click(object sender, RoutedEventArgs e) //otwarcie okna klientów
        {
            Klienciwin klienciwin = new Klienciwin();
            klienciwin.ShowDialog();
        }
        private void GoToPracownicy_Click(object sender, RoutedEventArgs e) //otwarcie pracowników
        {
            Pracownicywin pracownicywin = new Pracownicywin();
            pracownicywin.ShowDialog();
        }
        private void GoToUslugi_Click(object sender, RoutedEventArgs e) //otwarcie usług
        {
            Uslugiwin uslugiwin = new Uslugiwin();
            uslugiwin.ShowDialog();
        }
        private void GoToPobyty_Click(object sender, RoutedEventArgs e) //dodawanie nowej rezerwacji
        {
            DodajPobytwin dodajPobytwin = new DodajPobytwin();
            dodajPobytwin.ShowDialog();
            refresh();
        }
        private void grdPobyty_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e) //usuniecie wybranej rezerwacji
        {
            DataRowView x = (DataRowView)grdPobyty.SelectedItem;
            int id = (int)x.Row.ItemArray[7];//
            var pobyt = context.Pobyty.Find(id);
            context.Pobyty.Remove(pobyt);
            context.SaveChanges();
            refresh();
        }
    }
}
