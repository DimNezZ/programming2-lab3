using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3.Models
{
    internal class Set
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int SushiId { get; set; }
        public List<int>? Sauces { get; set; }
    }
}
