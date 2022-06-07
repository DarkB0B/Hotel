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
            int idPobytu = maxid + 1;
           
            try
            {
                if (nrKlientaTextBox.Text.Length == 9)
                {
                    if (peselTextBox.Text.Length == 11)
                    { 
                        
                        string nazwauslugi = uslugaComboBox.SelectedItem.ToString();
                        var usluga = context.Uslugi.SingleOrDefault(item => item.Usluga == nazwauslugi);

                        
                        List<string> kliencipesel = new List<string>();
                        foreach (var item in context.Klienci)
                        {
                            kliencipesel.Add(item.Pesel);
                            
                        }
                        if (kliencipesel.Contains(peselTextBox.Text))
                        {
                            
                            var klient = context.Klienci.SingleOrDefault(item => item.Pesel == peselTextBox.Text);
                            Pobyty pobyt = new Pobyty() { IdPobytu = idPobytu, DataPrzyjazdu = (DateTime)dataPrzyjazduDatePicker.SelectedDate, DataWyjazdu = (DateTime)dataWyjazduDatePicker.SelectedDate, IdPokoju = Convert.ToInt32(idPokojuTextBox.Text), IdPracownika = Convert.ToInt32(idPracownikaTextBox.Text), IdKlienta = klient.IdKlienta, IdUslugi = usluga.IdUslugi };
                            context.Pobyty.Add(pobyt);
                            context.SaveChanges();

                            this.Close();
                        }
                        else
                        {
                            int maxid2 = context.Klienci.Max(x => x.IdKlienta);
                            int idklienta = maxid2 + 1;
                            int nrklienta = Convert.ToInt32(nrKlientaTextBox.Text);
                           
                            
                            Klienci klient = new Klienci() { IdKlienta = idklienta, Imie = imieTextBox.Text, Nazwisko = nazwiskoTextBox.Text, NrKlienta = Convert.ToString(nrklienta), Pesel = peselTextBox.Text };
                            context.Klienci.Add(klient);
                            context.SaveChanges();
                            Pobyty pobyt = new Pobyty() { IdPobytu = idPobytu, DataPrzyjazdu = (DateTime)dataPrzyjazduDatePicker.SelectedDate, DataWyjazdu = (DateTime)dataWyjazduDatePicker.SelectedDate, IdPokoju = Convert.ToInt32(idPokojuTextBox.Text), IdPracownika = Convert.ToInt32(idPracownikaTextBox), IdKlienta = idklienta, IdUslugi = usluga.IdUslugi };
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

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dataPrzyjazduDatePicker.SelectedDate = DateTime.Now;
            dataWyjazduDatePicker.SelectedDate = DateTime.Now;
            List<string> uslugi = new List<string>();
            foreach (var item in context.Uslugi)
            {
                uslugi.Add(item.Usluga);
            }
            uslugaComboBox.ItemsSource = uslugi;
            System.Windows.Data.CollectionViewSource pobytyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pobytyViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // pobytyViewSource.Source = [generic data source]
        }

        private void uslugaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
