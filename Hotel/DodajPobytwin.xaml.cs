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
    /// Interaction logic for DodajPobytwin.xaml
    /// </summary>
    public partial class DodajPobytwin : Window
    {
        public DodajPobytwin()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            System.Windows.Data.CollectionViewSource pobytyViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("pobytyViewSource")));
            // Load data by setting the CollectionViewSource.Source property:
            // pobytyViewSource.Source = [generic data source]
        }
    }
}
