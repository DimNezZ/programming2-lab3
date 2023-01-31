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
    internal class AllSet
    {
        private readonly List<Set> set = new List<Set>();
        private static AllSet instance;

        private AllSet()
        {
            string jsonString = File.ReadAllText("./Resources/Set.json");
            set = JsonSerializer.Deserialize<List<Set>>(jsonString)!;
        }

        public static AllSet getInstance()
        {
            if (instance == null)
                instance = new AllSet();
            return instance;
        }

        public Set? GetById(int id)
        {
            for (int i = 0; i < set.Count; i++)
            {
                if (set[i].Id == id)
                {
                    return set[i];
                }
            }
            return null;
        }

        public List<Set> GetAllSet()
        {
            return set;
        }

        public void AddInList(Set newSet)
        {
            set.Add(newSet);
        }

        public void SaveToFile()
        {
            string jsonString = JsonSerializer.Serialize(set);
            File.WriteAllText("./Resources/Set.json", jsonString);
        }
    }
}
