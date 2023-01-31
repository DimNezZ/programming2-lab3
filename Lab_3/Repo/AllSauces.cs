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
    internal class AllSauces
    {
        private readonly List<Sauces> sauce = new List<Sauces>();
        private static AllSauces instance;

        private AllSauces()
        {
            string jsonString = File.ReadAllText("./Resources/Sauce.json");
            sauce = JsonSerializer.Deserialize<List<Sauces>>(jsonString)!;
        }

        public static AllSauces getInstance()
        {
            if (instance == null)
                instance = new AllSauces();
            return instance;
        }

        public Sauces? GetById(int id)
        {
            for (int i = 0; i < sauce.Count; i++)
            {
                if (sauce[i].Id == id)
                {
                    return sauce[i];
                }
            }
            return null;
        }

        public List<Sauces> GetAllSaucess()
        {
            return sauce;
        }
    }
}
