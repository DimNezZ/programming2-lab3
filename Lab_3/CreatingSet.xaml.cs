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
using System.Text.Json;
using System.Text.Json.Serialization;
using Lab_3.Repo;
using Lab_3.Models.JSON;

namespace Lab_3
{
    /// <summary>
    /// Логика взаимодействия для CreatingSet.xaml
    /// </summary>
    public partial class CreatingSet : Window
    {
        private AllSushi allSushi = AllSushi.getInstance();
        private AllSauces allSaucess = AllSauces.getInstance();
        private AllSet allSet = AllSet.getInstance();
        public CreatingSet()
        {
            InitializeComponent();
            ComboBoxTypeSushiCreate.ItemsSource = allSushi.GetAllSushi();
            ComboBoxSauceCreate.ItemsSource = allSaucess.GetAllSaucess();
            ComboBoxExtraSauceCreate.ItemsSource = allSaucess.GetAllSaucess();



            /*          int Id = 1;
                        string Name = "Праздничный набор";
                        int SushiId = 1;
                        int[] SaucesId = new int[] { 1, 2 };
                        int Price = 0;

                        Sushi mySushi = allSushi.GetById(SushiId);
                        List<Sauces> mySauces = new List<Sauces>();
                        foreach (int mySauceId in SaucesId)
                        {
                            mySauces.Add(allSaucess.GetById(mySauceId));
                        }

                        float totalPrice = Price + mySushi.Price;
                        foreach(Sauces mySauce in mySauces)
                        {
                            totalPrice += mySauce.Price;
                        }*/
        }

        private void ComboBoxTypeSushiCreate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sushi selectedSushi = (Sushi)ComboBoxTypeSushiCreate.SelectedItem;
        }

        private void ComboBoxSauceCreate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sauces selectedSauce = (Sauces)ComboBoxSauceCreate.SelectedItem;
            ButtonExtraSauceCreate.IsEnabled = true;
            ButtonCreate.IsEnabled = true;
        }

        private void ComboBoxExtraSauceCreate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Sauces selectedSauce = (Sauces)ComboBoxExtraSauceCreate.SelectedItem;
        }

        private void ButtonCreate_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            List<Set> elem = allSet.GetAllSet();
            for (int i = 0; i< elem.Count; i++)
            {
                if (elem[i].Id > id )
                {
                    id = (elem[i].Id);
                }
            }
            Set set = new Set();
            set.Id = id + 1;
            set.Name = TextBoxNameSetCreate.Text;
            set.SushiId =  0;
            if (ComboBoxTypeSushiCreate.SelectedItem != null)
            {
                Sushi selectedSushi = (Sushi)ComboBoxTypeSushiCreate.SelectedItem;
                set.SushiId = selectedSushi.Id;
            }
            set.Sauces = new List<int>();
            if (ComboBoxSauceCreate.SelectedItem != null)
            {
                Sauces selectedSauces = (Sauces)ComboBoxSauceCreate.SelectedItem;
                set.Sauces.Add(selectedSauces.Id);
            }
            if (ComboBoxExtraSauceCreate.SelectedItem != null)
            {
                Sauces selectedExtraSauces = (Sauces)ComboBoxExtraSauceCreate.SelectedItem;
                set.Sauces.Add(selectedExtraSauces.Id);
            }
            allSet.AddInList(set);
            allSet.SaveToFile();
            Hide();
        }

        private void ButtonExtraSauceCreate_Click(object sender, RoutedEventArgs e)
        {
            ComboBoxExtraSauceCreate.IsEnabled = true;
        }
    }
}
