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

namespace Hotel
{
    /// <summary>
    /// Interaction logic for DodajPracownikawin.xaml
    /// </summary>
    public partial class DodajPracownikawin : Window
    {
        HotelDbEntities context = new HotelDbEntities();
        public DodajPracownikawin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource pracownicyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pracownicyViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // pracownicyViewSource.Source = [generic data source]
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int maxid = context.Pracownicy.Max(x => x.IdPracownika);
            int idPracownika = maxid + 1; //utworzenie id o 1 większego niż największe id istniejące w bazie
            try //sprawdzenie czy nr telefonu oraz nr pesel mają właściwą liczbę znaków
            {
                if (nrPracownikaTextBox.Text.Length == 9)
                {
                    if (peselPracownikaTextBox.Text.Length == 11)
                    {


                        int nrpracownika = Convert.ToInt32(nrPracownikaTextBox.Text);
                        
                        Pracownicy pracownik = new Pracownicy() { IdPracownika = idPracownika, ImiePracownika = imiePracownikaTextBox.Text, NazwiskoPracownika = nazwiskoPracownikaTextBox.Text, NrPracownika = Convert.ToString(nrpracownika), PeselPracownika = peselPracownikaTextBox.Text };
                        context.Pracownicy.Add(pracownik);
                        context.SaveChanges();

                        this.Close();
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
    }
}
