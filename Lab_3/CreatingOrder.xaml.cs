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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.Json;
using System.Text.Json.Serialization;
using Lab_3.Models;
using static System.Net.Mime.MediaTypeNames;

namespace Lab_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CreatingOrder : Window

    {
        private AllSet allSet = AllSet.getInstance();
        public CreatingOrder()
        {
            InitializeComponent();
            ComboBoxNameSetOrder.ItemsSource = allSet.GetAllSet();
        }

        private void ButtonCreateNewSet_Click(object sender, RoutedEventArgs e)
        {
            CreatingSet CreatingSetWindow = new CreatingSet();
            CreatingSetWindow.ShowDialog();
        }

        private void ComboBoxNameSetOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            AllSet selectedSet = (AllSet)ComboBoxNameSetOrder.SelectedItem;
        }

        private void ComboBoxSizeSetOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
