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

namespace Hotel
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        HotelDbEntities context = new HotelDbEntities();
        CollectionViewSource klienciViewSource;
        CollectionViewSource pobytyViewSource;
        public MainWindow()
        {
            InitializeComponent();
            pobytyViewSource = ((CollectionViewSource)(FindResource("pobytyViewSource")));
            klienciViewSource = ((CollectionViewSource)(FindResource("klienciViewSource")));
            DataContext = this;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            context.Pobyty.Load();
           pobytyViewSource.Source = context.Pobyty.Local;
            
            // Load data by setting the CollectionViewSource.Source property:
             klienciViewSource.Source = context.Klienci.Local;
        }
        private void PreviousCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            
            klienciViewSource.View.MoveCurrentToPrevious();
        }

        private void NextCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            context.Klienci.Load();
            klienciViewSource.Source = context.Klienci.Local;
            klienciViewSource.View.MoveCurrentToNext();
            
        }
    }
}
