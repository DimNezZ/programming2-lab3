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
    internal class AllSushi
    {
        private readonly List<Sushi> sushi = new List<Sushi>();
        private static AllSushi instance;
        private AllSushi()
        {
            string jsonString = File.ReadAllText("./Resources/Sushi.json");
            sushi = JsonSerializer.Deserialize<List<Sushi>>(jsonString)!;
        }
        public static AllSushi getInstance()
        {
            if (instance == null)
                instance = new AllSushi();
            return instance;
        }

        public Sushi? GetById(int id)
        {
            for (int i = 0; i < sushi.Count; i++)
            {
                if (sushi[i].Id == id)
                {
                    return sushi[i];
                }
            }
            return null;
        }

        public List<Sushi> GetAllSushi()
        {
            return sushi;
        }
    }
}
