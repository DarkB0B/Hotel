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
    /// Interaction logic for DodajUslugewin.xaml
    /// </summary>
    public partial class DodajUslugewin : Window
    {
        HotelDbEntities context = new HotelDbEntities();
        public DodajUslugewin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource uslugiViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("uslugiViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // uslugiViewSource.Source = [generic data source]
        }
        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                int maxid = context.Uslugi.Max(x => x.IdUslugi);
                int idUslugi = maxid + 1;
                decimal cenaUslugi = Convert.ToDecimal(cenaUslugiTextBox.Text);
                Uslugi usluga = new Uslugi() { IdUslugi = idUslugi, CenaUslugi = cenaUslugi, Usluga = uslugaTextBox.Text };
                context.Uslugi.Add(usluga);
                context.SaveChanges();
                
                this.Close();
            }
            catch(Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }

        }
    }
}
