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
using System.Reflection.Emit;
using System.IO;
using Lab_3.Repo;
using Lab_3.Models.JSON;
using Lab_3.Models.DTO;

namespace Lab_3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CreatingOrder : Window

    {
        private readonly AllSet allSet = AllSet.getInstance();
        private readonly AllSushi allSushi = AllSushi.getInstance();
        private readonly AllSauces allSauces = AllSauces.getInstance();
        private readonly AllOrder allOrder = AllOrder.getInstance();

        private readonly List<CollectedOrder> orders = new List<CollectedOrder>();


        public CreatingOrder()
        {
            InitializeComponent();
            ComboBoxNameSetOrder.ItemsSource = allSet.GetAllSet();
            orders.Clear();
        }

        private void ButtonCreateNewSet_Click(object sender, RoutedEventArgs e)
        {
            CreatingSet CreatingSetWindow = new CreatingSet();
            CreatingSetWindow.ShowDialog();
        }

        private void ComboBoxNameSetOrder_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Set selectedSet = (Set)ComboBoxNameSetOrder.SelectedItem;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int count = int.Parse((string)LabelSouceCount.Content); 
            if (count >= 4)
            {
                ButtonAddSauce.IsEnabled = false;
            }
            count += 1;
            ButtonReduceSauce.IsEnabled = true;
            LabelSouceCount.Content = count.ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            int count = int.Parse((string)LabelSouceCount.Content);
            if (count <= 1)
            {
                ButtonReduceSauce.IsEnabled = false;
            }
            count -= 1;
            ButtonAddSauce.IsEnabled = true;
            LabelSouceCount.Content = count.ToString();
        }

        private void ButtonAddOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedSet = ComboBoxNameSetOrder.SelectedItem;
            if (selectedSet != null)
            {
                Set set = (Set)selectedSet;
                int sushiCount = 0;
                int sauceCount = int.Parse((string)LabelSouceCount.Content);

                switch (ComboBoxSizeSetOrder.SelectedIndex)
                {
                    case 0:
                        sushiCount = 10;
                        break;
                    case 1:
                        sushiCount = 20;
                        break;
                    case 2:
                        sushiCount = 30;
                        break;
                }

                CollectedOrder order = new CollectedOrder(set, sushiCount, sauceCount);
                List<string> orderParams = new List<string>
                {
                    $"Название: {order.GetSet().Name}",
                    $"Суши в наборе: {order.GetSushi()?.Name}",
                    $"Размер: {ComboBoxSizeSetOrder.Text}",
                    $"Порций соуса: {sauceCount}"
                };
                if (order.GetSauces().Count > 0)
                {
                    orderParams.Add($"Соусы в наборе: {string.Join(", ", order.GetSauces().Select(sauce => sauce.Name).ToList())}");
                }

                ListBoxOrder.Items.Add(string.Join("\n", orderParams));
                orders.Add(order);
            }

            double totalPrice = 0.0;
            foreach (CollectedOrder order in orders)
            {
                totalPrice += order.GetPrice();
            }
            LabelTotalCostOrder.Content = $"Общая стоимость: {Math.Round(totalPrice)}";
        }

        private void ButtonSaveOrder_Click(object sender, RoutedEventArgs e)
        {
            foreach (CollectedOrder order in orders)
            {
                allOrder.AddInList(order.GetModel());
            }

            allOrder.SaveToFile();
            ComboBoxSizeSetOrder.SelectedIndex = -1;
            ComboBoxNameSetOrder.SelectedIndex = -1;
            LabelTotalCostOrder.Content = "Общая стоимость:";
            LabelSouceCount.Content = "0";
            ButtonAddOrder.IsEnabled = false;
            ButtonReduceSauce.IsEnabled = false;
            orders.Clear();
            ListBoxOrder.Items.Clear();
        }
        private void Grid_MouseMove(object sender, MouseEventArgs e)
        {
            if (ComboBoxSizeSetOrder.SelectedIndex != -1 && ComboBoxNameSetOrder.SelectedIndex != -1)
            {
                ButtonAddOrder.IsEnabled = true;
            }
        }
    }
}
