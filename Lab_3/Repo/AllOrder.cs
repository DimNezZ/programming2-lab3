using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Lab_3.Models.JSON;

namespace Lab_3.Repo
{
    internal class AllOrder
    {
        private readonly List<Order> orders = new List<Order>();
        private static AllOrder instance;

        private AllOrder()
        {
            try
            {
                string jsonString = File.ReadAllText("./Resources/OrderHistory.json");
                orders = JsonSerializer.Deserialize<List<Order>>(jsonString)!;
            } catch (FileNotFoundException) { }
        }

        public static AllOrder getInstance()
        {
            if (instance == null)
                instance = new AllOrder();
            return instance;
        }
       
        public List<Order> GetAllOrders()
        {
            return orders;
        }

        public void AddInList(Order newOrder)
        {
            orders.Add(newOrder);
        }

        public void SaveToFile()
        {
            string jsonString = JsonSerializer.Serialize(orders);
            File.WriteAllText("./Resources/OrderHistory.json", jsonString);
        }
    }
}
